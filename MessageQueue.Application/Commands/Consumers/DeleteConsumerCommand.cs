using MessageQueue.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MessageQueue.Application.Commands.Consumers
{
    public record DeleteConsumerCommand(Guid Id) : ICommand<bool>;
}
