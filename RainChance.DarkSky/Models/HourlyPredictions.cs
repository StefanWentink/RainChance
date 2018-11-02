namespace RainChance.DarkSky.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class HourlyPredictions : SummaryPrediction
    {
        [JsonProperty(PropertyName = "data")]
        public List<HourlyPrediction> Hourly { get; set; }
    }
}