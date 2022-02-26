using FaStack.Bus;
using FaStack.Bus.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter("FaStack", LogLevel.Trace)
        .AddConsole();
});

ILogger<IBus> logger = loggerFactory.CreateLogger<IBus>();

var provider = new ServiceCollection()
    .AddBus(AppDomain.CurrentDomain.GetAssemblies())
    .BuildServiceProvider();

IMediator mediator = provider.GetService<IMediator>();
INotificationStore store = provider.GetService<INotificationStore>();

IBus bus = new Bus(mediator, logger, store);

bus.Notify(new Warning("Warning"));
bus.Notify(new Error("Error"));
bus.Notify(new InternalError(new Exception("Internal Error")));

logger.LogInformation("{HasNotification}", store.HasWarnings());
logger.LogInformation("{HasNotification}", store.HasErrors());
logger.LogInformation("{HasNotification}", store.HasInternalErrors());