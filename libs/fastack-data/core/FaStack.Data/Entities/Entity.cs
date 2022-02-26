using System;

using FaStack.Data.Abstractions;

namespace FaStack.Data.Entities
{
    public abstract class Entity<TId> : IEntity<TId>
        where TId : IEquatable<TId>
    {
        public TId Id { get; }

        public Entity(TId id)
        {
            Id = id;
        }

        public bool Equals(IEntity<TId>? other)
        {
            return
                other != null &&
                other is Entity<TId> &&
                other.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}