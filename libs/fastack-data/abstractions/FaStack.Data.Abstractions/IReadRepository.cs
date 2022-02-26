using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace FaStack.Data.Abstractions
{
    public interface IReadRepository<TEntity, TId> : IDisposable
        where TEntity : IAggregateRoot<TId>
        where TId : IEquatable<TId>
    {
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, PaginationFilter paginationFilter, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
