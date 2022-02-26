using System;

namespace FaStack.Data.Abstractions
{
    public interface IAggregateRoot<TId> : IEntity<TId>
        where TId : IEquatable<TId>
    { 
    
    }
}
