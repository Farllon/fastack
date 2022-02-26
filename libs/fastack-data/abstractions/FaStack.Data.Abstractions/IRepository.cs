using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FaStack.Data.Abstractions
{
    public interface IRepository<TEntity, TId> : IDisposable
        where TEntity : IAggregateRoot<TId>
        where TId : IEquatable<TId>
    {
        Task InsertOneAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task UpdateOneAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task DeleteOneAsync(TId id, CancellationToken cancellationToken = default);

        Task DeleteManyAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default);
    }
}
