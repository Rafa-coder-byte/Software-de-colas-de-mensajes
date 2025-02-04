using MediatR;
using MessageQueue.Application.Abstract;
using MessageQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Application.Queries.Consumers
{
    public record GetAllConsumersQuery() : IRequest<List<Consumer>>;
}
