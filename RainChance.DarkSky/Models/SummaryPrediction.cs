namespace RainChance.DarkSky.Models
{
    using Newtonsoft.Json;

    public class SummaryPrediction
    {
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }
}