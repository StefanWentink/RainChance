namespace RainChance
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using RainChance.Constants;
    using RainChance.DAL.Builders;
    using RainChance.DAL.Context;
    using RainChance.DAL.Extensions;
    using RainChance.DAL.Models;
    using RainChance.DAL.Repositories;
    using RainChance.DarkSky.Models;
    using RainChance.DL.Models;
    using RainChance.Extensions;
    using RainChance.Factories;
    using SWE.BasicType.Date.Extensions;
    using SWE.Http.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using RainChance.BL.Extensions;
    using RainChance.BL.Utilities;
    using Microsoft.ML.Legacy;
    using RainChance.DAL.Interfaces;
    using RainChance.BL.Interfaces;

    internal class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }

        private static ILogger Logger { get; set; }

        private static Dictionary<string, PredictionModel<PeriodValuesFlatData, DayData>> Trainers { get; set; }

        private static Dictionary<string, Func<IValueSelector, float>> Properties =
            new Dictionary<string, Func<IValueSelector, float>>
            {
                { nameof(PeriodValuesFlatData.PrecipIntensity), x => x.PrecipIntensity},
                { nameof(PeriodValuesFlatData.PrecipIntensityMax), x => x.PrecipIntensity},
                { nameof(PeriodValuesFlatData.Humidity), x => x.Humidity},
                { nameof(PeriodValuesFlatData.Pressure), x => x.Pressure},
                { nameof(PeriodValuesFlatData.WindSpeed), x => x.WindSpeed},
                { nameof(PeriodValuesFlatData.WindBearing), x => x.WindBearing},
                { nameof(PeriodValuesFlatData.CloudCover), x => x.CloudCover},
                { nameof(PeriodValuesFlatData.TemperatureHigh), x => x.TemperatureHigh},
                { nameof(PeriodValuesFlatData.TemperatureLow), x => x.TemperatureLow}
            };

        private static IConfigurationRoot Configuration { get; set; }

        private static void Main(string[] args)
        {
            // setup configuration
            Configuration = ConfigurationFactory.Create();

            // configure console logging
            Logger = new LoggerFactory()
                .AddConsole()
                .AddDebug()
                .CreateLogger<Program>();

            // setup our DI
            ServiceProvider = ServiceCollectionFactory
                .Create()
                .LoadDependancies(Logger);

            var input = ReadInput();

            while (input != 9)
            {
                var task = Task.Run(() => ProcessInput(input));

                if (!task.Result)
                {
                    input = ReadInput();
                }
            }

            Logger.LogInformation("Press any key to exit.");
            Console.Read();
        }

        private static async Task<bool> ProcessInput(int value)
        {
            var apiKey = Configuration.GetValue<string>("DarkSky:ApiKey");
            var cancellationToken = new CancellationToken();

            var intervalEnd = DateTimeOffset.Now.AddDays(-1).SetToStartOfDay();
            var referenceDate = intervalEnd;

            using (var rainChanceContext = new RainChanceContext())
            using (var dayPredictionRepository = new DayPredictionRepository(rainChanceContext))
            using (var hourPredictionRepository = new HourPredictionRepository(rainChanceContext))
            {
                var repository = ServiceProvider.GetRequiredService<IRepository<ResponsePrediction>>();

                switch (value)
                {
                    case 0:
                        var latest = (await dayPredictionRepository.GetNewestAsync().ConfigureAwait(false))?
                            .Time
                            .SetToStartOfDay() ?? referenceDate;

                        if (referenceDate > latest)
                        {
                            Logger.LogInformation($"We are already up to date till {intervalEnd.Date}.");
                            referenceDate = latest;
                        }

                        break;

                    case 1:
                        referenceDate = (await dayPredictionRepository.GetNewestAsync().ConfigureAwait(false))?
                            .Time
                            .AddDays(1)
                            .SetToStartOfDay() ?? referenceDate;

                        if (referenceDate > intervalEnd)
                        {
                            Logger.LogInformation($"We are already up to date till {intervalEnd.Date}.");
                        }

                        break;

                    case 2:

                        intervalEnd = (await dayPredictionRepository.GetOldestAsync()
                         .ConfigureAwait(false))
                         ?.Time.AddDays(-1).SetToStartOfDay() ?? intervalEnd;

                        referenceDate = intervalEnd
                            .AddMonths(-3)
                            .AddDays(1)
                            .SetToStartOfDay();

                        break;

                    case 5:
                        var collection = await dayPredictionRepository
                            .GetAllAsync()
                            .ConfigureAwait(false);
                        Trainers = new Dictionary<string, PredictionModel<PeriodValuesFlatData, DayData>>();

                        foreach (var properties in Properties)
                        {
                            Trainers.Add(properties.Key, await MachineLearningUtilities.SetupMachineLearning(dayPredictionRepository, properties.Value).ConfigureAwait(false));
                        }

                        return false;

                    case 8:
                        var dateTimeOffset = ReadPredictionInput();
                        while (dateTimeOffset.HasValue)
                        {
                            await ProcessPredictionInput(dateTimeOffset.Value, dayPredictionRepository).ConfigureAwait(false);
                            dateTimeOffset = ReadPredictionInput();
                        }

                        return true;
                }

                Logger.LogInformation($"Loading from {referenceDate.Date} to {intervalEnd}.");

                while (referenceDate <= intervalEnd)
                {
                    var darkSkyParams = new DarkSkyParams(
                        apiKey,
                        Coordinates.Latitude,
                        Coordinates.Longitude,
                        referenceDate);

                    var darkSkyResults = await repository.ReadAsync(cancellationToken, null, darkSkyParams.FormatUri())
                        .ConfigureAwait(false);

                    var darkSkyResult = darkSkyResults.SingleOrDefault();

                    Logger.LogDebug(darkSkyResult.ToString());

                    foreach (var daily in darkSkyResult.Daily.Daily)
                    {
                        var day = new DayPredictionBuilder(daily).SetOffsetHours(darkSkyResult.Offset).Build();
                        await dayPredictionRepository.AddAsync(day, cancellationToken).ConfigureAwait(false);

                        foreach (var hourly in darkSkyResult.Hourly.Hourly)
                        {
                            var hour = new HourPredictionBuilder(hourly).SetOffsetHours(darkSkyResult.Offset).Build();
                            hour.DayPredictionId = day.Id;

                            await hourPredictionRepository.AddAsync(hour, cancellationToken)
                                .ConfigureAwait(false);
                        }

                        var saveResult = await rainChanceContext.SaveChangesAsync(cancellationToken)
                            .ConfigureAwait(false);

                        Logger.LogInformation($"Processed {referenceDate.Date} : {saveResult}.");
                    }

                    referenceDate = referenceDate.AddDays(1).SetToStartOfDay();
                }
            }

            return false;
        }

        private static int ReadInput()
        {
            Logger.LogInformation(string.Empty);
            Logger.LogInformation("Choose one of the following options.");
            Logger.LogInformation("0. Read yesterday.");
            Logger.LogInformation("1. New entries untill yesterday.");
            Logger.LogInformation("2. Load year since oldest entry.");
            Logger.LogInformation($"5. Feed learning.");
            Logger.LogInformation("8. Start predicting.");
            Logger.LogInformation("9. Exit program.");
            Logger.LogInformation(string.Empty);

            var key = Console.ReadKey();

            if (key.KeyChar != '0'
                && key.KeyChar != '1'
                && key.KeyChar != '2'
                && key.KeyChar != '5'
                && key.KeyChar != '8'
                && key.KeyChar != '9')
            {
                Logger.LogInformation($"{key.KeyChar} input is invalid.");
                Logger.LogInformation(string.Empty);

                return ReadInput();
            }

            if (int.TryParse(key.KeyChar.ToString(), out int result))
            {
                return result;
            }

            return ReadInput();
        }

        private static DateTimeOffset? ReadPredictionInput()
        {
            Logger.LogInformation("Enter any date (dd-mm-yyyy)");
            Logger.LogInformation(string.Empty);

            var key = Console.ReadLine();
            if (key.Length != 10)
            {
                Logger.LogInformation("Invalid format (dd-mm-yyyy)");
                return null;
            }

            var split = key.Split('-');
            if (split.Length != 3)
            {
                Logger.LogInformation("Invalid format (dd-mm-yyyy)");
                return null;
            }

            if (int.TryParse(split[0], out var _day)
                && int.TryParse(split[1], out var _month)
                && int.TryParse(split[2], out var _year))
            {
                return new DateTimeOffset(new DateTime(_year, _month, _day));
            }

            Logger.LogInformation("Invalid format (dd-mm-yyyy)");
            return null;
        }

        private static async Task ProcessPredictionInput(
            DateTimeOffset dateTimeOffset,
            IPredictionRepository<DayPrediction> repository)
        {
            var intervalStart = dateTimeOffset.AddDays(-21);

            var data = (await repository
                .GetAllByExpressionAsync(x =>
                    x.Time >= intervalStart
                    && x.Time <= dateTimeOffset)
                .ConfigureAwait(false))
                .OrderByDescending(x => x.Time)
                .ToList();

            while (data.Count < 22)
            {
                dateTimeOffset = dateTimeOffset.AddDays(1);

                var entry = (await repository
                .GetAllByExpressionAsync(x =>
                    x.Time >= intervalStart
                    && x.Time <= dateTimeOffset)
                .ConfigureAwait(false))
                .OrderByDescending(x => x.Time)
                .ToList();

                data.Insert(0, data[data.Count - 1]);
            }

            var actualValue = data[0];
            var actualDayData = actualValue.ToDayData();
            var calculationData = data.ToPeriodValuesData();

            foreach (var property in Properties)
            {
                Logger.LogInformation($"Actual: {property.Key}={property.Value(actualDayData)}");
                var flatData = calculationData.ToFlatData(property.Value);
                var prediction = Trainers[property.Key].Predict(flatData);
                Logger.LogInformation($"Prediction: {property.Key}={property.Value(prediction)}");
            }

            var input = ReadPredictionInput();

            if (input.HasValue)
            {
                await ProcessPredictionInput(input.Value, repository);
            }
        }
    }
}