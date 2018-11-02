namespace RainChance.DAL.Builders
{
    using RainChance.DarkSky.Models;
    using RainChance.DL.Models;

    public class HourPredictionBuilder : BasePredictionBuilder<HourPrediction, HourlyPrediction>
    {
        public HourPredictionBuilder(HourlyPrediction member)
            : base(member)
        {
        }

        protected override HourPrediction BuildResult()
        {
            var result = base.BuildResult();

            result.Temperature = Member.Temperature;
            result.ApparentTemperature = Member.ApparentTemperature;

            return result;
        }
    }
}