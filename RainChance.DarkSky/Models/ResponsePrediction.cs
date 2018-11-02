namespace RainChance.DarkSky.Models
{
    using Newtonsoft.Json;

    public class ResponsePrediction
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string TimeZone { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public double Offset { get; set; }

        [JsonProperty(PropertyName = "hourly")]
        public HourlyPredictions Hourly { get; set; }

        [JsonProperty(PropertyName = "daily")]
        public DailyPredictions Daily { get; set; }
    }
}