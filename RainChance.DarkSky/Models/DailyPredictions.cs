namespace RainChance.DarkSky.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class DailyPredictions
    {
        [JsonProperty(PropertyName = "data")]
        public List<DailyPrediction> Daily { get; set; }
    }
}