using System;

namespace FaStack.Bus.Abstractions
{
    public sealed class InternalError : Notification
    {
        public Exception Exception { get; private set; }

        public InternalError(Exception exception)
            : base(exception.Message)
        {
            Exception = exception;
        }

        public InternalError(Exception exception, string message)
            : base(message)
        {
            Exception = exception;
        }
    }
}