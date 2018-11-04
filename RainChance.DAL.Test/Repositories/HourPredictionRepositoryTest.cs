namespace RainChance.DAL.Test.Repositories
{
    using RainChance.DAL.Interfaces;
    using RainChance.DAL.Repositories;
    using RainChance.DL.Models;

    public class HourPredictionRepositoryTest : PredictionRepositoryTest<HourPrediction>
    {
        internal override IPredictionRepository<HourPrediction> Repository =>
            new HourPredictionRepository(GetContextMock(Collection).Object);
    }
}