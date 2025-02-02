using MessageQueue.Application.Abstract;
using MessageQueue.Contracts;
using MessageQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Application.Queries.Producers
{
    public class GetProducerQueryHandler
   (IConsumerRepository consumerRepository,
   IUnitOfWork unitOfWork)
           : IQueryHandler<GetProducerQuery, Producer>
    {
        public Task<Producer> Handle(GetProducerQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return new Consumer;
        }
    }
}
