using MediatR;

namespace FaStack.Bus.Abstractions
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
        where TCommand : Command
    {

    }
}