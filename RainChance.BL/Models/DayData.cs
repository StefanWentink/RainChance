namespace RainChance.DL.Models
{
    using System;
    using System.Collections.Generic;

    public class DayData
    {
        public double PrecipIntensity { get; set; }

        public double PrecipProbability { get; set; }

        public double PrecipIntensityMax { get; set; }

        public double Humidity { get; set; }

        public double Pressure { get; set; }

        public double WindSpeed { get; set; }

        public int WindBearing { get; set; }

        public double CloudCover { get; set; }

        public double TemperatureHigh { get; set; }

        public double TemperatureLow { get; set; }
    }
}