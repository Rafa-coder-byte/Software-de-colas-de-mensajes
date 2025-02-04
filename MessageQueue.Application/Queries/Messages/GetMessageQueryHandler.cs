using MessageQueue.Application.Abstract;
using MessageQueue.Contracts;
using MessageQueue.Domain.Entities;


namespace MessageQueue.Application.Queries.Messages
{
    public class GetMessageQueryHandler
    (IConsumerRepository consumerRepository,
    IUnitOfWork unitOfWork)
            : IQueryHandler<GetMessageQuery, Message>
    {
        public Task<Message> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return new Consumer;
        }
    }
}
