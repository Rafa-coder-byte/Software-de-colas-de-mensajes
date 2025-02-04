using MessageQueue.Application.Abstract;
using MessageQueue.Contracts;
using MessageQueue.Domain.Entities;


namespace MessageQueue.Application.Queries.Consumers
{
    public class GetConsumerQueryHandler
    (IConsumerRepository consumerRepository,
    IUnitOfWork unitOfWork)
            : IQueryHandler<GetConsumerQuery, Consumer>
    {
        public Task<Consumer> Handle(GetConsumerQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return new Consumer;
        }
    }
}
