namespace RainChance.DAL.Repositories
{
    using RainChance.DAL.Context;
    using RainChance.DL.Models;

    public class DayPredictionRepository : PredictionRepository<DayPrediction>
    {
        public DayPredictionRepository(RainChanceContext context)
            : base(context)
        {
        }
    }
}