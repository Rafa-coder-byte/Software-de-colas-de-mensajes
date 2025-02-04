using MessageQueue.Application.Abstract;
using MessageQueue.Contracts;
using MessageQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Application.Commands.Consumers
{
    public class CreateConsumerCommandHandler
    (IConsumerRepository consumerRepository,
        IUnitOfWork unitOfWork)
                : ICommandHandler<CreateConsumerCommand, Consumer>
    {
        public Task<Consumer> Handle(CreateConsumerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return new Consumer;
        }
    }
}