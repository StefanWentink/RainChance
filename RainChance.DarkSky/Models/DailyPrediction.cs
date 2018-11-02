namespace RainChance.DarkSky.Models
{
    using Newtonsoft.Json;
    using RainChance.DarkSky.Interfaces;

    public class DailyPrediction : BasePrediction
    {
        [JsonProperty(PropertyName = "sunriseTime")]
        public long SunriseTime { get; set; }

        [JsonProperty(PropertyName = "sunsetTime")]
        public long SunsetTime { get; set; }

        [JsonProperty(PropertyName = "moonPhase")]
        public double MoonPhase { get; set; }

        [JsonProperty(PropertyName = "precipIntensityMax")]
        public double PrecipIntensityMax { get; set; }

        [JsonProperty(PropertyName = "precipIntensityMaxTime")]
        public long PrecipIntensityMaxTime { get; set; }

        [JsonProperty(PropertyName = "precipAccumulation")]
        public double PrecipAccumulation { get; set; }

        [JsonProperty(PropertyName = "precipType")]
        public string PrecipType { get; set; }

        [JsonProperty(PropertyName = "temperatureHigh")]
        public double TemperatureHigh { get; set; }

        [JsonProperty(PropertyName = "temperatureHighTime")]
        public long TemperatureHighTime { get; set; }

        [JsonProperty(PropertyName = "temperatureLow")]
        public double TemperatureLow { get; set; }

        [JsonProperty(PropertyName = "temperatureLowTime")]
        public long TemperatureLowTime { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureHigh")]
        public double ApparentTemperatureHigh { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureHighTime")]
        public long ApparentTemperatureHighTime { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureLow")]
        public double ApparentTemperatureLow { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureLowTime")]
        public long ApparentTemperatureLowTime { get; set; }

        [JsonProperty(PropertyName = "uvIndexTime")]
        public long UvIndexTime { get; set; }

        [JsonProperty(PropertyName = "temperatureMin")]
        public double TemperatureMin { get; set; }

        [JsonProperty(PropertyName = "temperatureMinTime")]
        public long TemperatureMinTime { get; set; }

        [JsonProperty(PropertyName = "temperatureMax")]
        public double TemperatureMax { get; set; }

        [JsonProperty(PropertyName = "temperatureMaxTime")]
        public long TemperatureMaxTime { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureMin")]
        public double ApparentTemperatureMin { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureMinTime")]
        public long ApparentTemperatureMinTime { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureMax")]
        public double ApparentTemperatureMax { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureMaxTime")]
        public long ApparentTemperatureMaxTime { get; set; }
    }
}