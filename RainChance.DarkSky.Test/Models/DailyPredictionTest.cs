namespace RainChance.DarkSky.Test
{
    using FluentAssertions;
    using global::Xunit;
    using Newtonsoft.Json;
    using RainChance.DarkSky.Models;
    using SWE.Xunit.Attributes;

    public class DailyPredictionTest
    {
        private const string _data = "{" +
              "\"time\": 255589200," +
              "\"summary\": \"Snow (9–14 in.) and windy starting in the afternoon.\"," +
              "\"icon\": \"snow\"," +
              "\"sunriseTime\": 255613996," +
              "\"sunsetTime\": 255650764," +
              "\"moonPhase\": 0.97," +
              "\"precipIntensity\": 0.0354," +
              "\"precipIntensityMax\": 0.1731," +
              "\"precipIntensityMaxTime\": 255657600," +
              "\"precipProbability\": 1," +
              "\"precipAccumulation\": 7.337," +
              "\"precipType\": \"snow\"," +
              "\"temperatureHigh\": 31.84," +
              "\"temperatureHighTime\": 255632400," +
              "\"temperatureLow\": 28.63," +
              "\"temperatureLowTime\": 255697200," +
              "\"apparentTemperatureHigh\": 20.47," +
              "\"apparentTemperatureHighTime\": 255625200," +
              "\"apparentTemperatureLow\": 13.03," +
              "\"apparentTemperatureLowTime\": 255697200," +
              "\"dewPoint\": 24.72," +
              "\"humidity\": 0.86," +
              "\"pressure\": 1016.41," +
              "\"windSpeed\": 22.93," +
              "\"windBearing\": 56," +
              "\"cloudCover\": 0.95," +
              "\"uvIndex\": 1," +
              "\"uvIndexTime\": 255621600," +
              "\"visibility\": 4.83," +
              "\"temperatureMin\": 22.72," +
              "\"temperatureMinTime\": 255596400," +
              "\"temperatureMax\": 32.04," +
              "\"temperatureMaxTime\": 255672000," +
              "\"apparentTemperatureMin\": 11.13," +
              "\"apparentTemperatureMinTime\": 255650400," +
              "\"apparentTemperatureMax\": 20.47," +
              "\"apparentTemperatureMaxTime\": 255625200" +
            "}";

        [Fact]
        [Category("DailyPrediction")]
        public void Serialize_Should_SetAllProperties()
        {
            var actual = JsonConvert.DeserializeObject<DailyPrediction>(_data);

            actual.Time.Should().Be(255589200);
            actual.Summary.Should().Be("Snow (9–14 in.) and windy starting in the afternoon.");
            actual.Icon.Should().Be("snow");
            actual.SunriseTime.Should().Be(255613996);
            actual.SunsetTime.Should().Be(255650764);
            actual.MoonPhase.Should().Be(0.97);
            actual.PrecipIntensity.Should().Be(0.0354);
            actual.PrecipIntensityMax.Should().Be(0.1731);
            actual.PrecipIntensityMaxTime.Should().Be(255657600);
            actual.PrecipProbability.Should().Be(1);
            actual.PrecipAccumulation.Should().Be(7.337);
            actual.PrecipType.Should().Be("snow");
            actual.TemperatureHigh.Should().Be(31.84);
            actual.TemperatureHighTime.Should().Be(255632400);
            actual.TemperatureLow.Should().Be(28.63);
            actual.TemperatureLowTime.Should().Be(255697200);
            actual.ApparentTemperatureHigh.Should().Be(20.47);
            actual.ApparentTemperatureHighTime.Should().Be(255625200);
            actual.ApparentTemperatureLow.Should().Be(13.03);
            actual.ApparentTemperatureLowTime.Should().Be(255697200);
            actual.DewPoint.Should().Be(24.72);
            actual.Humidity.Should().Be(0.86);
            actual.Pressure.Should().Be(1016.41);
            actual.WindSpeed.Should().Be(22.93);
            actual.WindBearing.Should().Be(56);
            actual.CloudCover.Should().Be(0.95);
            actual.UvIndex.Should().Be(1);
            actual.UvIndexTime.Should().Be(255621600);
            actual.Visibility.Should().Be(4.83);
            actual.TemperatureMin.Should().Be(22.72);
            actual.TemperatureMinTime.Should().Be(255596400);
            actual.TemperatureMax.Should().Be(32.04);
            actual.TemperatureMaxTime.Should().Be(255672000);
            actual.ApparentTemperatureMin.Should().Be(11.13);
            actual.ApparentTemperatureMinTime.Should().Be(255650400);
            actual.ApparentTemperatureMax.Should().Be(20.47);
            actual.ApparentTemperatureMaxTime.Should().Be(255625200);
        }
    }
}