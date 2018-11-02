namespace RainChance.DarkSky.Test
{
    using FluentAssertions;
    using global::Xunit;
    using Newtonsoft.Json;
    using RainChance.DarkSky.Models;
    using SWE.Xunit.Attributes;

    public class HourlyPredictionTest
    {
        private const string _data = "{" +
              "\"time\": 255589200," +
              "\"summary\": \"Mostly Cloudy\"," +
              "\"icon\": \"partly-cloudy-night\"," +
              "\"precipIntensity\": 0," +
              "\"precipProbability\": 0," +
              "\"temperature\": 22.8," +
              "\"apparentTemperature\": 16.46," +
              "\"dewPoint\": 15.51," +
              "\"humidity\": 0.73," +
              "\"pressure\": 1026.78," +
              "\"windSpeed\": 4.83," +
              "\"windBearing\": 354," +
              "\"cloudCover\": 0.78," +
              "\"uvIndex\": 0," +
              "\"visibility\": 9.62," +
            "}";

        [Fact]
        [Category("HourlyPrediction")]
        public void Serialize_Should_SetAllProperties()
        {
            var actual = JsonConvert.DeserializeObject<HourlyPrediction>(_data);

            actual.Time.Should().Be(255589200);
            actual.Summary.Should().Be("Mostly Cloudy");
            actual.Icon.Should().Be("partly-cloudy-night");
            actual.PrecipIntensity.Should().Be(0);
            actual.PrecipProbability.Should().Be(0);
            actual.Temperature.Should().Be(22.8);
            actual.ApparentTemperature.Should().Be(16.46);
            actual.DewPoint.Should().Be(15.51);
            actual.Humidity.Should().Be(0.73);
            actual.Pressure.Should().Be(1026.78);
            actual.WindSpeed.Should().Be(4.83);
            actual.WindBearing.Should().Be(354);
            actual.CloudCover.Should().Be(0.78);
            actual.UvIndex.Should().Be(0);
            actual.Visibility.Should().Be(9.62);
        }
    }
}