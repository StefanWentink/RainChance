using RainChance.BL.Interfaces;

namespace RainChance.DL.Models
{
    public class DayData : IValueSelector
    {
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
    }
}