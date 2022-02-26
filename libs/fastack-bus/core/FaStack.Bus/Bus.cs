using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.Extensions.Logging;

using FaStack.Bus.Abstractions;

namespace FaStack.Bus
{
    public class Bus : IBus
    {
        private IMediator _mediator;
        private ILogger<IBus> _logger;
        private INotificationStore _notificationStore;

        public Bus(
            IMediator mediator,
            ILogger<IBus> logger,
            INotificationStore notificationStore)
        {
            _logger = logger;
            _mediator = mediator;
            _notificationStore = notificationStore;
        }

        public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
            where TCommand : Command
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.Sending);

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.Validating);

            var validation = command.Validate();

            if (!validation.IsValid)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.ValidationFailluresFound);

                for (int i = 0; i < validation.Errors.Count; i++)
                    Notify(new Error(validation.Errors[i].ErrorMessage));

                return;
            }

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.NoValidationFailures);

            try
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.CallingMediator);

                await _mediator.Send(command);

                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.MediatorSuccess);
            }
            catch (Exception e)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.MediatorCallError);

                Notify(new InternalError(e));
            }

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.SendingEnd);
        }

        public async Task<TResponse> QueryAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default) 
            where TQuery : Query<TResponse>
        {
            TResponse result = default;

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.Querying);

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.Validating);

            var validation = query.Validate();

            if (!validation.IsValid)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.ValidationFailluresFound);

                for (int i = 0; i < validation.Errors.Count; i++)
                    Notify(new Error(validation.Errors[i].ErrorMessage));

                return result;
            }

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.NoValidationFailures);

            try
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.CallingMediator);

                result = await _mediator.Send(query);

                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.MediatorSuccess);
            }
            catch (Exception e)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.MediatorCallError);

                Notify(new InternalError(e));
            }

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.QueryingEnd);

            return result;
        }

        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
            where TEvent : Event
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.Publishing);

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.Validating);

            var validation = @event.Validate();

            if (!validation.IsValid)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.ValidationFailluresFound);

                for (int i = 0; i < validation.Errors.Count; i++)
                    Notify(new Error(validation.Errors[i].ErrorMessage));

                return;
            }

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.NoValidationFailures);

            try
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.CallingMediator);

                await _mediator.Publish(@event);

                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.MediatorSuccess);
            }
            catch (Exception e)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace(BusMessages.MediatorCallError);

                Notify(new InternalError(e));
            }

            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.PublishingEnd);
        }

        public void Notify<TNotificaiton>(TNotificaiton notification) 
            where TNotificaiton : Notification
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace(BusMessages.Notifying);

            if (notification is Warning)
                _notificationStore.AddWarning(notification as Warning);

            else if (notification is Error)
                _notificationStore.AddError(notification as Error);

            else if (notification is InternalError)
                _notificationStore.AddInternalError(notification as InternalError);
        }
    }
}
