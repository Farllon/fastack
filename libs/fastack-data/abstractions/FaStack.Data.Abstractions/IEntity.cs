using System;

namespace FaStack.Data.Abstractions
{
    public interface IEntity<TId> : IEquatable<IEntity<TId>>
        where TId : IEquatable<TId>
    {
        TId Id { get; }
    }
}
