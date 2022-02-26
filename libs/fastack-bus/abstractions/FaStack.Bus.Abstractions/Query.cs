using MediatR;

namespace FaStack.Bus.Abstractions
{
    public abstract class Query<TResponse> : Message, IRequest<TResponse> { }
}