using MediatR;

namespace FaStack.Bus.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : Query<TResponse>
    {

    }
}
