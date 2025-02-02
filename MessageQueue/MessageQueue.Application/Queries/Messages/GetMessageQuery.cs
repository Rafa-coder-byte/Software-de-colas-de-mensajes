using MediatR;
using MessageQueue.Domain.Entities;


namespace MessageQueue.Application.Queries.Messages
{
    public record GetMessageQuery(Guid Id) : IRequest<Message>;
}
