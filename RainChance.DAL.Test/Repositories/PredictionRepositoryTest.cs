namespace RainChance.DAL.Test.Repositories
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using RainChance.DAL.Context;
    using RainChance.DAL.Interfaces;
    using RainChance.DL.Models;
    using SWE.BasicType.Date.Extensions;
    using SWE.Xunit.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public abstract class PredictionRepositoryTest<T>
        where T : Prediction, new()
    {
        private static List<T> _collection;

        internal abstract IPredictionRepository<T> Repository { get; }

        internal List<T> Collection => _collection ?? (_collection = GetPredictions());

        private static DateTimeOffset _referenceDate = DateTimeOffset.Now.SetToStartOfDay();

        private static List<T> GetPredictions()
        {
            return new List<T>
            {
                new T { Time = _referenceDate.AddDays(2) },
                new T { Time = _referenceDate.AddDays(3) },
                new T { Time = _referenceDate.AddDays(0) },
                new T { Time = _referenceDate.AddDays(1) }
            };
        }

        [Theory]
        [Category("PredictionRepository")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void GetByKeyAsync_Should_ReturnCorrectRequestedKey(int index)
        {
            var repository = Repository;
            var id = Collection[index].Id;
            var actual = await repository.GetByKeyAsync(id).ConfigureAwait(false);
            actual.Id.Should().Be(id);
        }

        [Fact]
        [Category("PredictionRepository")]
        public async void GetNewestAsync_Should_ReturnCorrectRequestedKey()
        {
            var repository = Repository;
            var actual = await repository.GetNewestAsync().ConfigureAwait(false);
            actual.Time.Should().Be(_referenceDate.AddDays(3));
        }

        [Fact]
        [Category("PredictionRepository")]
        public async void GetOldestAsync_Should_ReturnCorrectRequestedKey()
        {
            var repository = Repository;
            var actual = await repository.GetOldestAsync().ConfigureAwait(false);
            actual.Time.Should().Be(_referenceDate);
        }

        internal Mock<RainChanceContext> GetContextMock(List<DayPrediction> dayPredictions)
        {
            return GetContextMock(dayPredictions, new List<HourPrediction>());
        }

        internal Mock<RainChanceContext> GetContextMock(List<HourPrediction> hourPredictions)
        {
            return GetContextMock(new List<DayPrediction>(), hourPredictions);
        }

        internal Mock<RainChanceContext> GetContextMock(List<DayPrediction> dayPredictions, List<HourPrediction> hourPredictions)
        {
            var result = new Mock<RainChanceContext>();

            result.Setup(m => m.Set<DayPrediction>()).Returns(GetMockSet(dayPredictions).Object);
            result.Setup(m => m.Set<HourPrediction>()).Returns(GetMockSet(hourPredictions).Object);

            result.Setup(c => c.DayPrediction).Returns(GetMockSet(dayPredictions).Object);
            result.Setup(c => c.HourPrediction).Returns(GetMockSet(hourPredictions).Object);

            return result;
        }

        private Mock<DbSet<TPrediction>> GetMockSet<TPrediction>(List<TPrediction> entities)
            where TPrediction : Prediction, new()
        {
            var query = entities.AsQueryable();

            var mockSet = new Mock<DbSet<TPrediction>>();
            mockSet.As<IQueryable<TPrediction>>().Setup(m => m.Provider).Returns(query.Provider);
            mockSet.As<IQueryable<TPrediction>>().Setup(m => m.Expression).Returns(query.Expression);
            mockSet.As<IQueryable<TPrediction>>().Setup(m => m.ElementType).Returns(query.ElementType);
            mockSet.As<IQueryable<TPrediction>>().Setup(m => m.GetEnumerator()).Returns(query.GetEnumerator());

            return mockSet;
        }
    }
}