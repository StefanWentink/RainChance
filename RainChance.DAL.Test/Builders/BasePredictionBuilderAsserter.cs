namespace RainChance.DAL.Test.Builders
{
    using FluentAssertions;
    using RainChance.DarkSky.Models;
    using RainChance.DL.Models;
    using SWE.BasicType.Date.Utilities;

    internal static class BasePredictionBuilderAsserter
    {
        internal static void Assert<TOut, TIn>(TOut result, TIn member)
        where TOut : Prediction
        where TIn : BasePrediction
        {
            result.Time.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.Time, 0));
            result.PrecipIntensity.Should().Be(member.PrecipIntensity);
            result.PrecipProbability.Should().Be(member.PrecipProbability);
            result.DewPoint.Should().Be(member.DewPoint);
            result.Humidity.Should().Be(member.Humidity);
            result.Pressure.Should().Be(member.Pressure);
            result.WindSpeed.Should().Be(member.WindSpeed);
            result.WindBearing.Should().Be(member.WindBearing);
            result.CloudCover.Should().Be(member.CloudCover);
            result.UvIndex.Should().Be(member.UvIndex);
            result.Visibility.Should().Be(member.Visibility);
        }
    }
}