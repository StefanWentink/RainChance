namespace RainChance.BL.Interfaces
{
    public interface IValueSelector
    {
        float PrecipIntensity { get; set; }
        float PrecipProbability { get; set; }
        float PrecipIntensityMax { get; set; }
        float Humidity { get; set; }
        float Pressure { get; set; }
        float WindSpeed { get; set; }
        float WindBearing { get; set; }
        float CloudCover { get; set; }
        float TemperatureHigh { get; set; }
        float TemperatureLow { get; set; }
    }
}