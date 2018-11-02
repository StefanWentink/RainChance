namespace RainChance.DAL.Test.Factories
{
    using RainChance.DarkSky.Models;

    internal static class DailyPredictionFactory
    {
        internal static DailyPrediction Create()
        {
            return new DailyPrediction
            {
                Time = 255589200,
                Summary = "Snow (9–14 in.) and windy starting in the afternoon.",
                Icon = "snow",
                SunriseTime = 255613996,
                SunsetTime = 255650764,
                MoonPhase = 0.97,
                PrecipIntensity = 0.0354,
                PrecipIntensityMax = 0.1731,
                PrecipIntensityMaxTime = 255657600,
                PrecipProbability = 1,
                PrecipAccumulation = 7.337,
                PrecipType = "snow",
                TemperatureHigh = 31.84,
                TemperatureHighTime = 255632400,
                TemperatureLow = 28.63,
                TemperatureLowTime = 255697200,
                ApparentTemperatureHigh = 20.47,
                ApparentTemperatureHighTime = 255625200,
                ApparentTemperatureLow = 13.03,
                ApparentTemperatureLowTime = 255697200,
                DewPoint = 24.72,
                Humidity = 0.86,
                Pressure = 1016.41,
                WindSpeed = 22.93,
                WindBearing = 56,
                CloudCover = 0.95,
                UvIndex = 1,
                UvIndexTime = 255621600,
                Visibility = 4.83,
                TemperatureMin = 22.72,
                TemperatureMinTime = 255596400,
                TemperatureMax = 32.04,
                TemperatureMaxTime = 255672000,
                ApparentTemperatureMin = 11.13,
                ApparentTemperatureMinTime = 255650400,
                ApparentTemperatureMax = 20.47,
                ApparentTemperatureMaxTime = 255625200
            };
        }
    }
}