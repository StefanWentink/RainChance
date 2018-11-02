namespace RainChance.DarkSky.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HourlyPrediction : BasePrediction
    {
        [JsonProperty(PropertyName = "temperature")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "apparentTemperature")]
        public double ApparentTemperature { get; set; }
    }
}