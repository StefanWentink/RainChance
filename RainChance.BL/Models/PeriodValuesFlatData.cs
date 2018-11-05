using RainChance.BL.Interfaces;

namespace RainChance.DL.Models
{
    public class PeriodValuesFlatData : IValueSelector
    {
        public float Label { get; set; }

        public float PrecipIntensity { get; set; }
        public float PrecipProbability { get; set; }
        public float PrecipIntensityMax { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public float WindSpeed { get; set; }
        public float WindBearing { get; set; }
        public float CloudCover { get; set; }
        public float TemperatureHigh { get; set; }
        public float TemperatureLow { get; set; }

        public float WeekPrecipIntensity_Min { get; set; }
        public float WeekPrecipIntensity_Max { get; set; }
        public float WeekPrecipIntensity_Average { get; set; }
        public float WeekPrecipIntensity_TrendDelta { get; set; }
        public float WeekPrecipIntensity_TrendIncreasing { get; set; }
        public float WeekPrecipIntensity_TrendDuration { get; set; }

        public float WeekPrecipProbability_Min { get; set; }
        public float WeekPrecipProbability_Max { get; set; }
        public float WeekPrecipProbability_Average { get; set; }
        public float WeekPrecipProbability_TrendDelta { get; set; }
        public float WeekPrecipProbability_TrendIncreasing { get; set; }
        public float WeekPrecipProbability_TrendDuration { get; set; }

        public float WeekPrecipIntensityMax_Min { get; set; }
        public float WeekPrecipIntensityMax_Max { get; set; }
        public float WeekPrecipIntensityMax_Average { get; set; }
        public float WeekPrecipIntensityMax_TrendDelta { get; set; }
        public float WeekPrecipIntensityMax_TrendIncreasing { get; set; }
        public float WeekPrecipIntensityMax_TrendDuration { get; set; }

        public float WeekHumidity_Min { get; set; }
        public float WeekHumidity_Max { get; set; }
        public float WeekHumidity_Average { get; set; }
        public float WeekHumidity_TrendDelta { get; set; }
        public float WeekHumidity_TrendIncreasing { get; set; }
        public float WeekHumidity_TrendDuration { get; set; }

        public float WeekPressure_Min { get; set; }
        public float WeekPressure_Max { get; set; }
        public float WeekPressure_Average { get; set; }
        public float WeekPressure_TrendDelta { get; set; }
        public float WeekPressure_TrendIncreasing { get; set; }
        public float WeekPressure_TrendDuration { get; set; }

        public float WeekWindSpeed_Min { get; set; }
        public float WeekWindSpeed_Max { get; set; }
        public float WeekWindSpeed_Average { get; set; }
        public float WeekWindSpeed_TrendDelta { get; set; }
        public float WeekWindSpeed_TrendIncreasing { get; set; }
        public float WeekWindSpeed_TrendDuration { get; set; }

        public float WeekWindBearing_Min { get; set; }
        public float WeekWindBearing_Max { get; set; }
        public float WeekWindBearing_Average { get; set; }
        public float WeekWindBearing_TrendDelta { get; set; }
        public float WeekWindBearing_TrendIncreasing { get; set; }
        public float WeekWindBearing_TrendDuration { get; set; }

        public float WeekCloudCover_Min { get; set; }
        public float WeekCloudCover_Max { get; set; }
        public float WeekCloudCover_Average { get; set; }
        public float WeekCloudCover_TrendDelta { get; set; }
        public float WeekCloudCover_TrendIncreasing { get; set; }
        public float WeekCloudCover_TrendDuration { get; set; }

        public float WeekTemperatureHigh_Min { get; set; }
        public float WeekTemperatureHigh_Max { get; set; }
        public float WeekTemperatureHigh_Average { get; set; }
        public float WeekTemperatureHigh_TrendDelta { get; set; }
        public float WeekTemperatureHigh_TrendIncreasing { get; set; }
        public float WeekTemperatureHigh_TrendDuration { get; set; }

        public float WeekTemperatureLow_Min { get; set; }
        public float WeekTemperatureLow_Max { get; set; }
        public float WeekTemperatureLow_Average { get; set; }
        public float WeekTemperatureLow_TrendDelta { get; set; }
        public float WeekTemperatureLow_TrendIncreasing { get; set; }
        public float WeekTemperatureLow_TrendDuration { get; set; }

        public float ThreeWeekPrecipIntensity_Min { get; set; }
        public float ThreeWeekPrecipIntensity_Max { get; set; }
        public float ThreeWeekPrecipIntensity_Average { get; set; }
        public float ThreeWeekPrecipIntensity_TrendSwitches { get; set; }

        public float ThreeWeekPrecipProbability_Min { get; set; }
        public float ThreeWeekPrecipProbability_Max { get; set; }
        public float ThreeWeekPrecipProbability_Average { get; set; }
        public float ThreeWeekPrecipProbability_TrendSwitches { get; set; }

        public float ThreeWeekPrecipIntensityMax_Min { get; set; }
        public float ThreeWeekPrecipIntensityMax_Max { get; set; }
        public float ThreeWeekPrecipIntensityMax_Average { get; set; }
        public float ThreeWeekPrecipIntensityMax_TrendSwitches { get; set; }

        public float ThreeWeekHumidity_Min { get; set; }
        public float ThreeWeekHumidity_Max { get; set; }
        public float ThreeWeekHumidity_Average { get; set; }
        public float ThreeWeekHumidity_TrendSwitches { get; set; }

        public float ThreeWeekPressure_Min { get; set; }
        public float ThreeWeekPressure_Max { get; set; }
        public float ThreeWeekPressure_Average { get; set; }
        public float ThreeWeekPressure_TrendSwitches { get; set; }

        public float ThreeWeekWindSpeed_Min { get; set; }
        public float ThreeWeekWindSpeed_Max { get; set; }
        public float ThreeWeekWindSpeed_Average { get; set; }
        public float ThreeWeekWindSpeed_TrendSwitches { get; set; }

        public float ThreeWeekWindBearing_Min { get; set; }
        public float ThreeWeekWindBearing_Max { get; set; }
        public float ThreeWeekWindBearing_Average { get; set; }
        public float ThreeWeekWindBearing_TrendSwitches { get; set; }

        public float ThreeWeekCloudCover_Min { get; set; }
        public float ThreeWeekCloudCover_Max { get; set; }
        public float ThreeWeekCloudCover_Average { get; set; }
        public float ThreeWeekCloudCover_TrendSwitches { get; set; }

        public float ThreeWeekTemperatureHigh_Min { get; set; }
        public float ThreeWeekTemperatureHigh_Max { get; set; }
        public float ThreeWeekTemperatureHigh_Average { get; set; }
        public float ThreeWeekTemperatureHigh_TrendSwitches { get; set; }

        public float ThreeWeekTemperatureLow_Min { get; set; }
        public float ThreeWeekTemperatureLow_Max { get; set; }
        public float ThreeWeekTemperatureLow_Average { get; set; }
        public float ThreeWeekTemperatureLow_TrendSwitches { get; set; }
    }
}