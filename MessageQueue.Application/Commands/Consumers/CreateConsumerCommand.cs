using MessageQueue.Application.Abstract;
using MessageQueue.Domain.Entities;
using MessageQueue.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MessageQueue.Application.Commands.Consumers
{
    public record CreateConsumerCommand(
       NetworkEndpoint Endpoint ) : ICommand<Consumer>;
}
