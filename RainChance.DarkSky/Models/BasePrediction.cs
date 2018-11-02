namespace RainChance.DarkSky.Models
{
    using Newtonsoft.Json;
    using RainChance.DarkSky.Interfaces;

    public class BasePrediction : SummaryPrediction, IBasePrediction
    {
        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "precipIntensity")]
        public double PrecipIntensity { get; set; }

        [JsonProperty(PropertyName = "precipProbability")]
        public double PrecipProbability { get; set; }

        [JsonProperty(PropertyName = "dewPoint")]
        public double DewPoint { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public double Humidity { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public double Pressure { get; set; }

        [JsonProperty(PropertyName = "windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty(PropertyName = "windBearing")]
        public int WindBearing { get; set; }

        [JsonProperty(PropertyName = "cloudCover")]
        public double CloudCover { get; set; }

        [JsonProperty(PropertyName = "uvIndex")]
        public double UvIndex { get; set; }

        [JsonProperty(PropertyName = "visibility")]
        public double Visibility { get; set; }
    }
}