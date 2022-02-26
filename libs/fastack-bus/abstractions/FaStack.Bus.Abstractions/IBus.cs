using System.Threading;
using System.Threading.Tasks;

namespace FaStack.Bus.Abstractions
{
    public interface IBus
    {
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : Command;

        Task<TResponse> QueryAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : Query<TResponse>;

        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : Event;

        void Notify<TNotificaiton>(TNotificaiton notification)
            where TNotificaiton : Notification;
    }
}
