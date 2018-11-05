namespace RainChance.DAL.Repositories
{
    using RainChance.DAL.Context;
    using RainChance.DAL.Interfaces;
    using RainChance.DAL.Utilities;
    using RainChance.DL.Interfaces;
    using SWE.EntityFramework.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class PredictionRepository<T> : IPredictionRepository<T>, IDisposable
        where T : class, IPrediction
    {
        protected bool IsDisposed { get; private set; }

        protected RainChanceContext Context { get; }

        protected PredictionRepository(RainChanceContext context)
        {
            Context = context;
        }

        public async Task<T> GetByKeyAsync(Guid key)
        {
            return await Context.Set<T>()
                .SingleOrDefaultAsyncSafe(PredictionQueryUtilities.IdExpression<T, Guid>(key))
                .ConfigureAwait(false);
        }

        public async Task<List<T>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().ToListAsyncSafe(cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<T>> GetAllByExpressionAsync(
            Expression<Func<T, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().Where(expression).ToListAsyncSafe(cancellationToken).ConfigureAwait(false);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await Context.Set<T>()
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<T> GetOldestAsync()
        {
            return await Context.Set<T>()
                .OrderBy(PredictionQueryUtilities.OrderByTime<T>())
                .FirstOrDefaultAsyncSafe()
                .ConfigureAwait(false);
        }

        public async Task<T> GetNewestAsync()
        {
            return await Context.Set<T>()
                .OrderByDescending(PredictionQueryUtilities.OrderByTime<T>())
                .FirstOrDefaultAsyncSafe()
                .ConfigureAwait(false);
        }

        ~PredictionRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;

                if (isDisposing)
                {
                    Context?.Dispose();
                }
            }
        }
    }
}