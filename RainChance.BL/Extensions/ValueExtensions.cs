namespace RainChance.BL.Extensions
{
    using RainChance.BL.Interfaces;
    using RainChance.DL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ValueExtensions
    {
        internal static ValueData<float> ToValueData(
            this IEnumerable<float> values)
        {
            var min = values.Min();
            var max = values.Max();

            int trendSwitches = 0;
            float trendDelta = 0;
            bool? trendIncreasing = null;
            int trendDuration = 0;

            var firstValue = values.First();
            var lastValue = firstValue;
            var lastTrendStart = firstValue;

            foreach (var value in values.Skip(1))
            {
                var increasing = value > lastValue;

                trendDelta = value - lastTrendStart;

                if (trendIncreasing != increasing)
                {
                    trendDuration = 0;

                    if (trendIncreasing != null)
                    {
                        trendSwitches++;
                        lastTrendStart = lastValue;
                    }

                    trendIncreasing = increasing;
                }

                trendDuration++;
                lastValue = value;
            }

            return new ValueData<float>
            {
                Average = values.Average(),
                Count = values.Count(),
                Delta = max - min,
                Min = min,
                Max = values.Max(),
                Latest = values.LastOrDefault(),
                TrendSwitches = trendSwitches,
                TrendDelta = trendDelta,
                TrendIncreasing = trendIncreasing ?? false,
                TrendDuration = trendDuration
            };
        }

        internal static ValuesData ToValuesData(
            this IEnumerable<DayPrediction> values)
        {
            return values.Select(ToDayData).ToValuesData();
        }

        internal static ValuesData ToValuesData(
            this IEnumerable<DayData> values)
        {
            return new ValuesData
            {
                PrecipIntensity = values.Select(x => x.PrecipIntensity).ToValueData(),
                PrecipProbability = values.Select(x => x.PrecipProbability).ToValueData(),
                PrecipIntensityMax = values.Select(x => x.PrecipIntensityMax).ToValueData(),
                Humidity = values.Select(x => x.Humidity).ToValueData(),
                Pressure = values.Select(x => x.Pressure).ToValueData(),
                WindSpeed = values.Select(x => x.WindSpeed).ToValueData(),
                WindBearing = values.Select(x => x.WindBearing).Cast<float>().ToValueData(),
                CloudCover = values.Select(x => x.CloudCover).ToValueData(),
                TemperatureHigh = values.Select(x => x.TemperatureHigh).ToValueData(),
                TemperatureLow = values.Select(x => x.TemperatureLow).ToValueData(),
            };
        }

        public static DayData ToDayData(this DayPrediction dayPrediction)
        {
            return new DayData
            {
                PrecipIntensity = (float)dayPrediction.PrecipIntensity,
                PrecipProbability = (float)dayPrediction.PrecipProbability,
                PrecipIntensityMax = (float)dayPrediction.PrecipIntensityMax,
                Humidity = (float)dayPrediction.Humidity,
                Pressure = (float)dayPrediction.Pressure,
                WindSpeed = (float)dayPrediction.WindSpeed,
                WindBearing = dayPrediction.WindBearing,
                CloudCover = (float)dayPrediction.CloudCover,
                TemperatureHigh = (float)dayPrediction.TemperatureHigh,
                TemperatureLow = (float)dayPrediction.TemperatureLow
            };
        }

        public static PeriodValuesData ToPeriodValuesData(
            this IEnumerable<DayPrediction> values)
        {
            if (values.Count() < 22)
            {
                throw new ArgumentException("Needs a minimum of 3 weeks of historic data.");
            }

            var dayData = values
                .OrderByDescending(x => x.Time)
                .FirstOrDefault()
                .ToDayData();

            var weekData = values
                .OrderByDescending(x => x.Time)
                .Skip(1)
                .Take(7)
                .OrderBy(x => x.Time)
                .Select(ToDayData);

            var threeWeekData = values
                .OrderByDescending(x => x.Time)
                .Skip(1)
                .Take(21)
                .OrderBy(x => x.Time)
                .Select(ToDayData);

            return new PeriodValuesData
            {
                DayData = dayData,
                WeekHistory = weekData.ToValuesData(),
                ThreeWeekHistory = threeWeekData.ToValuesData()
            };
        }

        public static PeriodValuesFlatData ToFlatData(
            this PeriodValuesData data,
            Func<IValueSelector, float> labelSelector)
        {
            return new PeriodValuesFlatData
            {
                Label = labelSelector(data.DayData),

                PrecipIntensity = data.DayData.PrecipIntensity,
                PrecipProbability = data.DayData.PrecipProbability,
                PrecipIntensityMax = data.DayData.PrecipIntensityMax,
                Humidity = data.DayData.Humidity,
                Pressure = data.DayData.Pressure,
                WindSpeed = data.DayData.WindSpeed,
                WindBearing = data.DayData.WindBearing,
                CloudCover = data.DayData.CloudCover,
                TemperatureHigh = data.DayData.TemperatureHigh,
                TemperatureLow = data.DayData.TemperatureLow,

                WeekPrecipIntensity_Min = data.WeekHistory.PrecipIntensity.Min,
                WeekPrecipIntensity_Max = data.WeekHistory.PrecipIntensity.Max,
                WeekPrecipIntensity_Average = data.WeekHistory.PrecipIntensity.Average,
                WeekPrecipIntensity_TrendDelta = data.WeekHistory.PrecipIntensity.TrendDelta,
                WeekPrecipIntensity_TrendIncreasing = data.WeekHistory.PrecipIntensity.TrendIncreasing ? 1 : 0,
                WeekPrecipIntensity_TrendDuration = data.WeekHistory.PrecipIntensity.TrendDuration,

                WeekPrecipProbability_Min = data.WeekHistory.PrecipProbability.Min,
                WeekPrecipProbability_Max = data.WeekHistory.PrecipProbability.Max,
                WeekPrecipProbability_Average = data.WeekHistory.PrecipProbability.Average,
                WeekPrecipProbability_TrendDelta = data.WeekHistory.PrecipProbability.TrendDelta,
                WeekPrecipProbability_TrendIncreasing = data.WeekHistory.PrecipProbability.TrendIncreasing ? 1 : 0,
                WeekPrecipProbability_TrendDuration = data.WeekHistory.PrecipProbability.TrendDuration,

                WeekPrecipIntensityMax_Min = data.WeekHistory.PrecipIntensityMax.Min,
                WeekPrecipIntensityMax_Max = data.WeekHistory.PrecipIntensityMax.Max,
                WeekPrecipIntensityMax_Average = data.WeekHistory.PrecipIntensityMax.Average,
                WeekPrecipIntensityMax_TrendDelta = data.WeekHistory.PrecipIntensityMax.TrendDelta,
                WeekPrecipIntensityMax_TrendIncreasing = data.WeekHistory.PrecipIntensityMax.TrendIncreasing ? 1 : 0,
                WeekPrecipIntensityMax_TrendDuration = data.WeekHistory.PrecipIntensityMax.TrendDuration,

                WeekHumidity_Min = data.WeekHistory.Humidity.Min,
                WeekHumidity_Max = data.WeekHistory.Humidity.Max,
                WeekHumidity_Average = data.WeekHistory.Humidity.Average,
                WeekHumidity_TrendDelta = data.WeekHistory.Humidity.TrendDelta,
                WeekHumidity_TrendIncreasing = data.WeekHistory.Humidity.TrendIncreasing ? 1 : 0,
                WeekHumidity_TrendDuration = data.WeekHistory.Humidity.TrendDuration,

                WeekPressure_Min = data.WeekHistory.Pressure.Min,
                WeekPressure_Max = data.WeekHistory.Pressure.Max,
                WeekPressure_Average = data.WeekHistory.Pressure.Average,
                WeekPressure_TrendDelta = data.WeekHistory.Pressure.TrendDelta,
                WeekPressure_TrendIncreasing = data.WeekHistory.Pressure.TrendIncreasing ? 1 : 0,
                WeekPressure_TrendDuration = data.WeekHistory.Pressure.TrendDuration,

                WeekWindSpeed_Min = data.WeekHistory.WindSpeed.Min,
                WeekWindSpeed_Max = data.WeekHistory.WindSpeed.Max,
                WeekWindSpeed_Average = data.WeekHistory.WindSpeed.Average,
                WeekWindSpeed_TrendDelta = data.WeekHistory.WindSpeed.TrendDelta,
                WeekWindSpeed_TrendIncreasing = data.WeekHistory.WindSpeed.TrendIncreasing ? 1 : 0,
                WeekWindSpeed_TrendDuration = data.WeekHistory.WindSpeed.TrendDuration,

                WeekWindBearing_Min = data.WeekHistory.WindBearing.Min,
                WeekWindBearing_Max = data.WeekHistory.WindBearing.Max,
                WeekWindBearing_Average = data.WeekHistory.WindBearing.Average,
                WeekWindBearing_TrendDelta = data.WeekHistory.WindBearing.TrendDelta,
                WeekWindBearing_TrendIncreasing = data.WeekHistory.WindBearing.TrendIncreasing ? 1 : 0,
                WeekWindBearing_TrendDuration = data.WeekHistory.WindBearing.TrendDuration,

                WeekCloudCover_Min = data.WeekHistory.CloudCover.Min,
                WeekCloudCover_Max = data.WeekHistory.CloudCover.Max,
                WeekCloudCover_Average = data.WeekHistory.CloudCover.Average,
                WeekCloudCover_TrendDelta = data.WeekHistory.CloudCover.TrendDelta,
                WeekCloudCover_TrendIncreasing = data.WeekHistory.CloudCover.TrendIncreasing ? 1 : 0,
                WeekCloudCover_TrendDuration = data.WeekHistory.CloudCover.TrendDuration,

                WeekTemperatureHigh_Min = data.WeekHistory.TemperatureHigh.Min,
                WeekTemperatureHigh_Max = data.WeekHistory.TemperatureHigh.Max,
                WeekTemperatureHigh_Average = data.WeekHistory.TemperatureHigh.Average,
                WeekTemperatureHigh_TrendDelta = data.WeekHistory.TemperatureHigh.TrendDelta,
                WeekTemperatureHigh_TrendIncreasing = data.WeekHistory.TemperatureHigh.TrendIncreasing ? 1 : 0,
                WeekTemperatureHigh_TrendDuration = data.WeekHistory.TemperatureHigh.TrendDuration,

                WeekTemperatureLow_Min = data.WeekHistory.TemperatureLow.Min,
                WeekTemperatureLow_Max = data.WeekHistory.TemperatureLow.Max,
                WeekTemperatureLow_Average = data.WeekHistory.TemperatureLow.Average,
                WeekTemperatureLow_TrendDelta = data.WeekHistory.TemperatureLow.TrendDelta,
                WeekTemperatureLow_TrendIncreasing = data.WeekHistory.TemperatureLow.TrendIncreasing ? 1 : 0,
                WeekTemperatureLow_TrendDuration = data.WeekHistory.TemperatureLow.TrendDuration,

                ThreeWeekPrecipIntensity_Min = data.ThreeWeekHistory.PrecipIntensity.Min,
                ThreeWeekPrecipIntensity_Max = data.ThreeWeekHistory.PrecipIntensity.Max,
                ThreeWeekPrecipIntensity_Average = data.ThreeWeekHistory.PrecipIntensity.Average,
                ThreeWeekPrecipIntensity_TrendSwitches = data.ThreeWeekHistory.PrecipIntensity.TrendSwitches,

                ThreeWeekPrecipProbability_Min = data.ThreeWeekHistory.PrecipProbability.Min,
                ThreeWeekPrecipProbability_Max = data.ThreeWeekHistory.PrecipProbability.Max,
                ThreeWeekPrecipProbability_Average = data.ThreeWeekHistory.PrecipProbability.Average,
                ThreeWeekPrecipProbability_TrendSwitches = data.ThreeWeekHistory.PrecipProbability.TrendSwitches,

                ThreeWeekPrecipIntensityMax_Min = data.ThreeWeekHistory.PrecipIntensityMax.Min,
                ThreeWeekPrecipIntensityMax_Max = data.ThreeWeekHistory.PrecipIntensityMax.Max,
                ThreeWeekPrecipIntensityMax_Average = data.ThreeWeekHistory.PrecipIntensityMax.Average,
                ThreeWeekPrecipIntensityMax_TrendSwitches = data.ThreeWeekHistory.PrecipIntensityMax.TrendSwitches,

                ThreeWeekHumidity_Min = data.ThreeWeekHistory.Humidity.Min,
                ThreeWeekHumidity_Max = data.ThreeWeekHistory.Humidity.Max,
                ThreeWeekHumidity_Average = data.ThreeWeekHistory.Humidity.Average,
                ThreeWeekHumidity_TrendSwitches = data.ThreeWeekHistory.Humidity.TrendSwitches,

                ThreeWeekPressure_Min = data.ThreeWeekHistory.Pressure.Min,
                ThreeWeekPressure_Max = data.ThreeWeekHistory.Pressure.Max,
                ThreeWeekPressure_Average = data.ThreeWeekHistory.Pressure.Average,
                ThreeWeekPressure_TrendSwitches = data.ThreeWeekHistory.Pressure.TrendSwitches,

                ThreeWeekWindSpeed_Min = data.ThreeWeekHistory.WindSpeed.Min,
                ThreeWeekWindSpeed_Max = data.ThreeWeekHistory.WindSpeed.Max,
                ThreeWeekWindSpeed_Average = data.ThreeWeekHistory.WindSpeed.Average,
                ThreeWeekWindSpeed_TrendSwitches = data.ThreeWeekHistory.WindSpeed.TrendSwitches,

                ThreeWeekWindBearing_Min = data.ThreeWeekHistory.WindBearing.Min,
                ThreeWeekWindBearing_Max = data.ThreeWeekHistory.WindBearing.Max,
                ThreeWeekWindBearing_Average = data.ThreeWeekHistory.WindBearing.Average,
                ThreeWeekWindBearing_TrendSwitches = data.ThreeWeekHistory.WindBearing.TrendSwitches,

                ThreeWeekCloudCover_Min = data.ThreeWeekHistory.CloudCover.Min,
                ThreeWeekCloudCover_Max = data.ThreeWeekHistory.CloudCover.Max,
                ThreeWeekCloudCover_Average = data.ThreeWeekHistory.CloudCover.Average,
                ThreeWeekCloudCover_TrendSwitches = data.ThreeWeekHistory.CloudCover.TrendSwitches,

                ThreeWeekTemperatureHigh_Min = data.ThreeWeekHistory.TemperatureHigh.Min,
                ThreeWeekTemperatureHigh_Max = data.ThreeWeekHistory.TemperatureHigh.Max,
                ThreeWeekTemperatureHigh_Average = data.ThreeWeekHistory.TemperatureHigh.Average,
                ThreeWeekTemperatureHigh_TrendSwitches = data.ThreeWeekHistory.TemperatureHigh.TrendSwitches,

                ThreeWeekTemperatureLow_Min = data.ThreeWeekHistory.TemperatureLow.Min,
                ThreeWeekTemperatureLow_Max = data.ThreeWeekHistory.TemperatureLow.Max,
                ThreeWeekTemperatureLow_Average = data.ThreeWeekHistory.TemperatureLow.Average,
                ThreeWeekTemperatureLow_TrendSwitches = data.ThreeWeekHistory.TemperatureLow.TrendSwitches,
            };
        }
    }
}