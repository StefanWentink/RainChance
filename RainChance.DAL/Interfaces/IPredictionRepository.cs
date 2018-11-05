namespace RainChance.DAL.Interfaces
{
    using RainChance.DL.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPredictionRepository<T>
        where T : class, IPrediction
    {
        Task<T> GetByKeyAsync(Guid key);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<List<T>> GetAllByExpressionAsync(
            Expression<Func<T, bool>> expression,
            CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        Task<T> GetOldestAsync();

        Task<T> GetNewestAsync();
    }
}