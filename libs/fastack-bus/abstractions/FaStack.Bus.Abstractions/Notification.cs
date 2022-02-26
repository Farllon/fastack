using FluentValidation.Results;

namespace FaStack.Bus.Abstractions
{
    public abstract class Notification : Message
    {
        public string Message { get; private set; }

        public Notification(string message)
        {
            Message = message;
        }

        public override ValidationResult Validate()
            => new ValidationResult();
    }
}