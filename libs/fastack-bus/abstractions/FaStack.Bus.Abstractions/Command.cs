using MediatR;

namespace FaStack.Bus.Abstractions
{
    public abstract class Command : Message, IRequest { }
}