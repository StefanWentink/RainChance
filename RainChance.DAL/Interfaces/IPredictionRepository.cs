namespace RainChance.DAL.Interfaces
{
    using RainChance.DL.Interfaces;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPredictionRepository<T>
        where T : class, IPrediction
    {
        Task<T> GetByKeyAsync(Guid key);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        Task<T> GetOldestAsync();

        Task<T> GetNewestAsync();
    }
}