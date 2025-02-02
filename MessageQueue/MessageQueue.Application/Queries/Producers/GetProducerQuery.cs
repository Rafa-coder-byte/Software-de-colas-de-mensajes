using MediatR;
using MessageQueue.Domain.Entities;


namespace MessageQueue.Application.Queries.Producers
{
    public record GetProducerQuery(Guid Id) : IRequest<Producer>;
}
