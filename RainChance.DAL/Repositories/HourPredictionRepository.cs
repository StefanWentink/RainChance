namespace RainChance.DAL.Repositories
{
    using RainChance.DAL.Context;
    using RainChance.DL.Models;

    public class HourPredictionRepository : PredictionRepository<HourPrediction>
    {
        public HourPredictionRepository(RainChanceContext context)
            : base(context)
        {
        }
    }
}