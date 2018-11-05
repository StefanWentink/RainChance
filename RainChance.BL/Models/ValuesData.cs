namespace RainChance.DL.Models
{
    public class ValuesData
    {
        public ValueData<float> PrecipIntensity { get; set; }

        public ValueData<float> PrecipProbability { get; set; }

        public ValueData<float> PrecipIntensityMax { get; set; }

        public ValueData<float> Humidity { get; set; }

        public ValueData<float> Pressure { get; set; }

        public ValueData<float> WindSpeed { get; set; }

        public ValueData<float> WindBearing { get; set; }

        public ValueData<float> CloudCover { get; set; }

        public ValueData<float> TemperatureHigh { get; set; }

        public ValueData<float> TemperatureLow { get; set; }
    }
}