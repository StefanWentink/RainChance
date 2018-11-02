namespace RainChance.DAL.Test.Builders
{
    using FluentAssertions;
    using global::Xunit;
    using Newtonsoft.Json;
    using RainChance.DAL.Builders;
    using RainChance.DAL.Test.Factories;
    using RainChance.DarkSky.Models;
    using SWE.Xunit.Attributes;

    public class HourPredictionBuilderTest
    {
        [Fact]
        [Category("HourPredictionBuilder")]
        public void Build_Should_Return_HourPrediction_With_AllPropertiesSet()
        {
            var member = HourlyPredictionFactory.Create();
            var result = new HourPredictionBuilder(member).Build();

            BasePredictionBuilderAsserter.Assert(result, member);

            result.Temperature.Should().Be(member.Temperature);
            result.ApparentTemperature.Should().Be(member.ApparentTemperature);
        }
    }
}