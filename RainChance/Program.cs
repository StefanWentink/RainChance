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
    using RainChance.DarkSky.Models;
    using RainChance.Extensions;
    using RainChance.Factories;
    using SWE.BasicType.Date.Extensions;
    using SWE.Http.Interfaces;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }

        private static ILogger Logger { get; set; }

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
                Task.Run(() => ProcessInput(input));
                input = ReadInput();
            }

            Logger.LogInformation("Press any key to exit.");
            Console.Read();
        }

        private static async void ProcessInput(int value)
        {
            var apiKey = Configuration.GetValue<string>("DarkSky:ApiKey");
            var cancellationToken = new CancellationToken();
            var context = new RainChanceContext();

            //var intervalEnd = DateTimeOffset.Now.AddDays(-1).SetToStartOfDay();
            var intervalEnd = DateTimeOffset.Now.AddDays(-2).SetToStartOfDay();
            var referenceDate = intervalEnd.AddYears(-value);
            var repository = ServiceProvider.GetRequiredService<IRepository<ResponsePrediction>>();

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
                    await context.AddAsync(day, cancellationToken).ConfigureAwait(false);

                    foreach (var hourly in darkSkyResult.Hourly.Hourly)
                    {
                        var hour = new HourPredictionBuilder(hourly).SetOffsetHours(darkSkyResult.Offset).Build();
                        hour.DayPredictionId = day.Id;

                        await context.AddAsync(hour, cancellationToken)
                            .ConfigureAwait(false);
                    }

                    await context.SaveChangesAsync(cancellationToken)
                        .ConfigureAwait(false);
                }

                referenceDate = referenceDate.AddDays(1).SetToStartOfDay();
            }
        }

        private static int ReadInput()
        {
            Logger.LogInformation(string.Empty);
            Logger.LogInformation("Choose one of the following options.");
            Logger.LogInformation("0. Read yesterday.");
            Logger.LogInformation("1. Last years.");
            Logger.LogInformation("2. Last 2 years.");
            Logger.LogInformation("9. Exit program.");
            Logger.LogInformation(string.Empty);

            var key = Console.ReadKey();

            if (key.KeyChar != '0'
                && key.KeyChar != '1'
                && key.KeyChar != '2'
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
    }
}