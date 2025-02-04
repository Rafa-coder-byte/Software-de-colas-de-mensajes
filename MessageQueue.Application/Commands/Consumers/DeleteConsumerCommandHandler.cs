using MessageQueue.Application.Abstract;
using MessageQueue.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Application.Commands.Consumers
{
    public class DeleteConsumerCommandHandler
    (IConsumerRepository consumerRepository,
        IUnitOfWork unitOfWork)
                : ICommandHandler<DeleteConsumerCommand, bool>
    {
        public Task<bool> Handle(DeleteConsumerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return new Consumer;
        }
    }
}
