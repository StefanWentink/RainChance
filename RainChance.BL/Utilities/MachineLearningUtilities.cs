namespace RainChance.BL.Utilities
{
    using Microsoft.ML.Legacy;
    using Microsoft.ML.Legacy.Data;
    using Microsoft.ML.Legacy.Trainers;
    using Microsoft.ML.Legacy.Transforms;
    using RainChance.BL.Extensions;
    using RainChance.BL.Interfaces;
    using RainChance.DAL.Interfaces;
    using RainChance.DL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class MachineLearningUtilities
    {
        public static async Task<PredictionModel<PeriodValuesFlatData, DayData>> SetupMachineLearning(
            IPredictionRepository<DayPrediction> repository,
            Func<IValueSelector, float> labelSelector)
        {
            var collection = await repository
                            .GetAllAsync()
                            .ConfigureAwait(false);

            return SetupMachineLearning(collection, labelSelector);
        }

        public static PredictionModel<PeriodValuesFlatData, DayData> SetupMachineLearning(
            List<DayPrediction> collection,
            Func<IValueSelector, float> labelSelector)
        {
            var calculationCollection = new List<DayPrediction>();
            var calculationRanges = new List<PeriodValuesFlatData>();

            foreach (var item in collection.OrderByDescending(x => x.Time))
            {
                calculationCollection.Insert(0, item);

                if (calculationCollection.Count == 22)
                {
                    var calculationRange = calculationCollection
                        .ToPeriodValuesData()
                        .ToFlatData(labelSelector);
                    calculationRanges.Add(calculationRange);
                    calculationCollection.RemoveAt(21);
                }
            }

            return MachineLearningUtilities.Learn(calculationRanges);
        }

        internal static PredictionModel<PeriodValuesFlatData, DayData> Learn(
            this IEnumerable<PeriodValuesFlatData> values)
        {
            var pipeline = new LearningPipeline();
            var collection = CollectionDataSource.Create(values);
            pipeline.Add(collection);
            pipeline.Add(GetColumns());
            pipeline.Append(new FastTreeRegressor());
            return pipeline.Train<PeriodValuesFlatData, DayData>();
        }

        public static ColumnConcatenator GetColumns()
        {
            return new ColumnConcatenator(
            "Features",
            nameof(PeriodValuesFlatData.Label),
            //nameof(PeriodValuesFlatData.PrecipIntensity),
            //nameof(PeriodValuesFlatData.PrecipProbability),
            //nameof(PeriodValuesFlatData.PrecipIntensityMax),
            //nameof(PeriodValuesFlatData.Humidity),
            //nameof(PeriodValuesFlatData.Pressure),
            //nameof(PeriodValuesFlatData.WindSpeed),
            //nameof(PeriodValuesFlatData.WindBearing),
            //nameof(PeriodValuesFlatData.CloudCover),
            //nameof(PeriodValuesFlatData.TemperatureHigh),
            //nameof(PeriodValuesFlatData.TemperatureLow),

            nameof(PeriodValuesFlatData.WeekPrecipIntensity_Min),
            nameof(PeriodValuesFlatData.WeekPrecipIntensity_Max),
            nameof(PeriodValuesFlatData.WeekPrecipIntensity_Average),
            nameof(PeriodValuesFlatData.WeekPrecipIntensity_TrendDelta),
            nameof(PeriodValuesFlatData.WeekPrecipIntensity_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekPrecipIntensity_TrendDuration),

            nameof(PeriodValuesFlatData.WeekPrecipProbability_Min),
            nameof(PeriodValuesFlatData.WeekPrecipProbability_Max),
            nameof(PeriodValuesFlatData.WeekPrecipProbability_Average),
            nameof(PeriodValuesFlatData.WeekPrecipProbability_TrendDelta),
            nameof(PeriodValuesFlatData.WeekPrecipProbability_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekPrecipProbability_TrendDuration),

            nameof(PeriodValuesFlatData.WeekPrecipIntensityMax_Min),
            nameof(PeriodValuesFlatData.WeekPrecipIntensityMax_Max),
            nameof(PeriodValuesFlatData.WeekPrecipIntensityMax_Average),
            nameof(PeriodValuesFlatData.WeekPrecipIntensityMax_TrendDelta),
            nameof(PeriodValuesFlatData.WeekPrecipIntensityMax_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekPrecipIntensityMax_TrendDuration),

            nameof(PeriodValuesFlatData.WeekHumidity_Min),
            nameof(PeriodValuesFlatData.WeekHumidity_Max),
            nameof(PeriodValuesFlatData.WeekHumidity_Average),
            nameof(PeriodValuesFlatData.WeekHumidity_TrendDelta),
            nameof(PeriodValuesFlatData.WeekHumidity_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekHumidity_TrendDuration),

            nameof(PeriodValuesFlatData.WeekPressure_Min),
            nameof(PeriodValuesFlatData.WeekPressure_Max),
            nameof(PeriodValuesFlatData.WeekPressure_Average),
            nameof(PeriodValuesFlatData.WeekPressure_TrendDelta),
            nameof(PeriodValuesFlatData.WeekPressure_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekPressure_TrendDuration),

            nameof(PeriodValuesFlatData.WeekWindSpeed_Min),
            nameof(PeriodValuesFlatData.WeekWindSpeed_Max),
            nameof(PeriodValuesFlatData.WeekWindSpeed_Average),
            nameof(PeriodValuesFlatData.WeekWindSpeed_TrendDelta),
            nameof(PeriodValuesFlatData.WeekWindSpeed_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekWindSpeed_TrendDuration),

            nameof(PeriodValuesFlatData.WeekWindBearing_Min),
            nameof(PeriodValuesFlatData.WeekWindBearing_Max),
            nameof(PeriodValuesFlatData.WeekWindBearing_Average),
            nameof(PeriodValuesFlatData.WeekWindBearing_TrendDelta),
            nameof(PeriodValuesFlatData.WeekWindBearing_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekWindBearing_TrendDuration),

            nameof(PeriodValuesFlatData.WeekCloudCover_Min),
            nameof(PeriodValuesFlatData.WeekCloudCover_Max),
            nameof(PeriodValuesFlatData.WeekCloudCover_Average),
            nameof(PeriodValuesFlatData.WeekCloudCover_TrendDelta),
            nameof(PeriodValuesFlatData.WeekCloudCover_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekCloudCover_TrendDuration),

            nameof(PeriodValuesFlatData.WeekTemperatureHigh_Min),
            nameof(PeriodValuesFlatData.WeekTemperatureHigh_Max),
            nameof(PeriodValuesFlatData.WeekTemperatureHigh_Average),
            nameof(PeriodValuesFlatData.WeekTemperatureHigh_TrendDelta),
            nameof(PeriodValuesFlatData.WeekTemperatureHigh_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekTemperatureHigh_TrendDuration),

            nameof(PeriodValuesFlatData.WeekTemperatureLow_Min),
            nameof(PeriodValuesFlatData.WeekTemperatureLow_Max),
            nameof(PeriodValuesFlatData.WeekTemperatureLow_Average),
            nameof(PeriodValuesFlatData.WeekTemperatureLow_TrendDelta),
            nameof(PeriodValuesFlatData.WeekTemperatureLow_TrendIncreasing),
            nameof(PeriodValuesFlatData.WeekTemperatureLow_TrendDuration),

            nameof(PeriodValuesFlatData.ThreeWeekPrecipIntensity_Min),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipIntensity_Max),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipIntensity_Average),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipIntensity_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekPrecipProbability_Min),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipProbability_Max),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipProbability_Average),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipProbability_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekPrecipIntensityMax_Min),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipIntensityMax_Max),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipIntensityMax_Average),
            nameof(PeriodValuesFlatData.ThreeWeekPrecipIntensityMax_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekHumidity_Min),
            nameof(PeriodValuesFlatData.ThreeWeekHumidity_Max),
            nameof(PeriodValuesFlatData.ThreeWeekHumidity_Average),
            nameof(PeriodValuesFlatData.ThreeWeekHumidity_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekPressure_Min),
            nameof(PeriodValuesFlatData.ThreeWeekPressure_Max),
            nameof(PeriodValuesFlatData.ThreeWeekPressure_Average),
            nameof(PeriodValuesFlatData.ThreeWeekPressure_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekWindSpeed_Min),
            nameof(PeriodValuesFlatData.ThreeWeekWindSpeed_Max),
            nameof(PeriodValuesFlatData.ThreeWeekWindSpeed_Average),
            nameof(PeriodValuesFlatData.ThreeWeekWindSpeed_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekWindBearing_Min),
            nameof(PeriodValuesFlatData.ThreeWeekWindBearing_Max),
            nameof(PeriodValuesFlatData.ThreeWeekWindBearing_Average),
            nameof(PeriodValuesFlatData.ThreeWeekWindBearing_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekCloudCover_Min),
            nameof(PeriodValuesFlatData.ThreeWeekCloudCover_Max),
            nameof(PeriodValuesFlatData.ThreeWeekCloudCover_Average),
            nameof(PeriodValuesFlatData.ThreeWeekCloudCover_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekTemperatureHigh_Min),
            nameof(PeriodValuesFlatData.ThreeWeekTemperatureHigh_Max),
            nameof(PeriodValuesFlatData.ThreeWeekTemperatureHigh_Average),
            nameof(PeriodValuesFlatData.ThreeWeekTemperatureHigh_TrendSwitches),

            nameof(PeriodValuesFlatData.ThreeWeekTemperatureLow_Min),
            nameof(PeriodValuesFlatData.ThreeWeekTemperatureLow_Max),
            nameof(PeriodValuesFlatData.ThreeWeekTemperatureLow_Average),
            nameof(PeriodValuesFlatData.ThreeWeekTemperatureLow_TrendSwitches));
        }
    }
}