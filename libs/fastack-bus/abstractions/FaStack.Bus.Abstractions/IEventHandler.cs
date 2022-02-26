using MediatR;

namespace FaStack.Bus.Abstractions
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : Event
    {

    }
}
