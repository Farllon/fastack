using FluentValidation.Results;
using System;

namespace FaStack.Bus.Abstractions
{
    public abstract class Message : IEquatable<Message>
    {
        public Guid Id { get; }

        public DateTime SentIn { get; }

        public Type Sender { get; }

        public Message()
        {
            Id = Guid.NewGuid();
            SentIn = DateTime.UtcNow;
            Sender = GetType();
        }

        public override bool Equals(object obj)
            => Equals(obj as Message);

        public override int GetHashCode()
            => HashCode.Combine(Id, SentIn, Sender);

        public bool Equals(Message? other)
            => other != null && 
                other is Message &&
                other.Id == Id;

        public abstract ValidationResult Validate();
    }
}