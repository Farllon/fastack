using FluentValidation.Results;

namespace FaStack.Bus.Abstractions
{
    public sealed class Warning : Notification
    {
        public Warning(string message)
            : base(message)
        {

        }
    }
}