namespace RainChance.DL.Models
{
    using System;
    using System.Collections.Generic;

    public class DayPrediction : Prediction
    {
        public DateTimeOffset SunriseTime { get; set; }

        public DateTimeOffset SunsetTime { get; set; }

        public double MoonPhase { get; set; }

        public double PrecipIntensityMax { get; set; }

        public DateTimeOffset PrecipIntensityMaxTime { get; set; }

        public double PrecipAccumulation { get; set; }

        public string PrecipType { get; set; }

        public double TemperatureHigh { get; set; }

        public DateTimeOffset TemperatureHighTime { get; set; }

        public double TemperatureLow { get; set; }

        public DateTimeOffset TemperatureLowTime { get; set; }

        public double ApparentTemperatureHigh { get; set; }

        public DateTimeOffset ApparentTemperatureHighTime { get; set; }

        public double ApparentTemperatureLow { get; set; }

        public DateTimeOffset ApparentTemperatureLowTime { get; set; }

        public DateTimeOffset UvIndexTime { get; set; }

        public double TemperatureMin { get; set; }

        public DateTimeOffset TemperatureMinTime { get; set; }

        public double TemperatureMax { get; set; }

        public DateTimeOffset TemperatureMaxTime { get; set; }

        public double ApparentTemperatureMin { get; set; }

        public DateTimeOffset ApparentTemperatureMinTime { get; set; }

        public double ApparentTemperatureMax { get; set; }

        public DateTimeOffset ApparentTemperatureMaxTime { get; set; }

        public virtual ICollection<HourPrediction> HourPredictions { get; set; } = new List<HourPrediction>();
    }
}