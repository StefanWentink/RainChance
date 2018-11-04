namespace RainChance.DAL.Utilities
{
    using RainChance.DL.Interfaces;
    using SWE.Model.Interfaces;
    using System;
    using System.Linq.Expressions;

    internal static class PredictionQueryUtilities
    {
        internal static Expression<Func<T, bool>> IdExpression<T, TKey>(TKey key)
            where T : IKey<TKey>
            where TKey : IEquatable<TKey>
        {
            return x => x.Id.Equals(key);
        }

        internal static Expression<Func<T, DateTimeOffset>> OrderByTime<T>()
            where T : IPrediction
        {
            return x => x.Time;
        }
    }
}