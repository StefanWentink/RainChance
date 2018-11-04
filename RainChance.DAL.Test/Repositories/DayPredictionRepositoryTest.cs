namespace RainChance.DAL.Test.Repositories
{
    using RainChance.DAL.Interfaces;
    using RainChance.DAL.Repositories;
    using RainChance.DL.Models;

    public class DayPredictionRepositoryTest : PredictionRepositoryTest<DayPrediction>
    {
        internal override IPredictionRepository<DayPrediction> Repository =>
            new DayPredictionRepository(GetContextMock(Collection).Object);
    }
}