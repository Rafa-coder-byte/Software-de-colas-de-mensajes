using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using MessageQueue.Application.Commands.Consumers;
using MessageQueue.Application.Queries.Consumers;
using MessageQueue.Contracts;
using MessageQueue.GrpcProtos;

namespace MessageQueue.GrpcService.Services
{
    public class ConsumerService : Consumer.ConsumerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ConsumerService> _logger;

        public ConsumerService(IMediator mediator, IMapper mapper, ILogger<ConsumerService> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<ConsumerDTO> CreateConsumer(CreateConsumerDTORequest request, ServerCallContext context)
        {
            var command = new CreateConsumerCommand(_mapper.Map<Domain.ValueObjects.NetworkEndpoint>(request.Endpoint));
            var result = await _mediator.Send(command);
            return _mapper.Map<ConsumerDTO>(result);
        }

        public override async Task<ConsumerDTO> GetConsumer(GetRequest request, ServerCallContext context)
        {
            var query = new GetConsumerQuery(_mapper.Map<Guid>(request.Id));
            var result = await _mediator.Send(query);
            return _mapper.Map<ConsumerDTO>(result);
        }

        public override async Task<Consumers> GetAllConsumers(Empty request, ServerCallContext context)
        {
            var query = new GetAllConsumersQuery();
            var result = await _mediator.Send(query);
            return _mapper.Map<Consumers>(result);
        }

        public override async Task<Empty> DeleteConsumer(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteConsumerCommand(_mapper.Map<Guid>(request.Id));
            await _mediator.Send(command);
            return new Empty();
        }
    }
}

