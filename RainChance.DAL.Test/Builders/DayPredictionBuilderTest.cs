namespace RainChance.DAL.Test.Builders
{
    using FluentAssertions;
    using global::Xunit;
    using RainChance.DAL.Builders;
    using RainChance.DAL.Test.Factories;
    using SWE.BasicType.Date.Utilities;
    using SWE.Xunit.Attributes;

    public class DayPredictionBuilderTest
    {
        [Fact]
        [Category("DayPredictionBuilder")]
        public void Build_Should_Return_DayPrediction_With_AllPropertiesSet()
        {
            var member = DailyPredictionFactory.Create();
            var result = new DayPredictionBuilder(member).Build();

            BasePredictionBuilderAsserter.Assert(result, member);

            result.SunriseTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.SunriseTime, 0));
            result.SunsetTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.SunsetTime, 0));
            result.MoonPhase.Should().Be(member.MoonPhase);
            result.PrecipIntensityMax.Should().Be(member.PrecipIntensityMax);
            result.PrecipIntensityMaxTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.PrecipIntensityMaxTime, 0));
            result.PrecipAccumulation.Should().Be(member.PrecipAccumulation);
            result.PrecipType.Should().Be(member.PrecipType);
            result.TemperatureHigh.Should().Be(member.TemperatureHigh);
            result.TemperatureHighTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.TemperatureHighTime, 0));
            result.TemperatureLow.Should().Be(member.TemperatureLow);
            result.TemperatureLowTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.TemperatureLowTime, 0));
            result.ApparentTemperatureHigh.Should().Be(member.ApparentTemperatureHigh);
            result.ApparentTemperatureHighTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.ApparentTemperatureHighTime, 0));
            result.ApparentTemperatureLow.Should().Be(member.ApparentTemperatureLow);
            result.ApparentTemperatureLowTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.ApparentTemperatureLowTime, 0));
            result.UvIndexTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.UvIndexTime, 0));
            result.TemperatureMin.Should().Be(member.TemperatureMin);
            result.TemperatureMinTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.TemperatureMinTime, 0));
            result.TemperatureMax.Should().Be(member.TemperatureMax);
            result.TemperatureMaxTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.TemperatureMaxTime, 0));
            result.ApparentTemperatureMin.Should().Be(member.ApparentTemperatureMin);
            result.ApparentTemperatureMinTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.ApparentTemperatureMinTime, 0));
            result.ApparentTemperatureMax.Should().Be(member.ApparentTemperatureMax);
            result.ApparentTemperatureMaxTime.Should().Be(ConversionUtilities.UnixTimeStampToDateTimeOffset(member.ApparentTemperatureMaxTime, 0));
        }
    }
}