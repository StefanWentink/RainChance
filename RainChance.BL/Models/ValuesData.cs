namespace RainChance.DL.Models
{
    using System;
    using System.Collections.Generic;

    public class ValuesData
    {
        public ValueData<double> PrecipIntensity { get; set; }

        public ValueData<double> PrecipProbability { get; set; }

        public ValueData<double> PrecipIntensityMax { get; set; }

        public ValueData<double> Humidity { get; set; }

        public ValueData<double> Pressure { get; set; }

        public ValueData<double> WindSpeed { get; set; }

        public ValueData<int> WindBearing { get; set; }

        public ValueData<double> CloudCover { get; set; }

        public ValueData<double> TemperatureHigh { get; set; }

        public ValueData<double> TemperatureLow { get; set; }
    }
}