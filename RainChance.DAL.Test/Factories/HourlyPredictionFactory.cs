namespace RainChance.DAL.Test.Factories
{
    using RainChance.DarkSky.Models;

    internal static class HourlyPredictionFactory
    {
        internal static HourlyPrediction Create()
        {
            return new HourlyPrediction
            {
                Time = 255589200,
                Summary = "Mostly Cloudy",
                Icon = "partly-cloudy-night",
                PrecipIntensity = 0,
                PrecipProbability = 0,
                Temperature = 22.8,
                ApparentTemperature = 16.46,
                DewPoint = 15.51,
                Humidity = 0.73,
                Pressure = 1026.78,
                WindSpeed = 4.83,
                WindBearing = 354,
                CloudCover = 0.78,
                UvIndex = 0,
                Visibility = 9.62,
            };
        }
    }
}