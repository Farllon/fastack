using MediatR;

namespace FaStack.Bus.Abstractions
{
    public abstract class Event : Message, INotification { }
}