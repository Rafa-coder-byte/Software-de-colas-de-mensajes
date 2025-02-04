using MediatR;

namespace MessageQueue.Application.Abstract
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {

    }
}
