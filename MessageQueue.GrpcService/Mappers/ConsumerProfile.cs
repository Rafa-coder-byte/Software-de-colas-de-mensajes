using AutoMapper;

using MessageQueue.GrpcProtos;


namespace MessageQueue.GrpcService.Mappers
{
    public class ConsumerProfile : Profile
    {
        public ConsumerProfile()
        {
            CreateMap<ConsumerDTO, Domain.Entities.Consumer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.Endpoint.Port, opt => opt.MapFrom(src => (int)src.Endpoint.Port));

            CreateMap<Domain.Entities.Consumer, ConsumerDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Endpoint.Port, opt => opt.MapFrom(src => (int)src.Endpoint.Port));

            CreateMap<NetworkEndpoint, Domain.ValueObjects.NetworkEndpoint>()
                .ForMember(dest => dest.IP, opt => opt.MapFrom(src => src.Ip))
                .ForMember(dest => dest.Port, opt => opt.MapFrom(src => (int)src.Port));

            CreateMap<Domain.ValueObjects.NetworkEndpoint, NetworkEndpoint>()
                .ForMember(dest => dest.Ip, opt => opt.MapFrom(src => src.IP))
                .ForMember(dest => dest.Port, opt => opt.MapFrom(src => (int)src.Port));

            CreateMap<string, Guid>()
         .ForMember(dest => dest, opt => opt.MapFrom(src => Guid.Parse(src)));

            CreateMap<Guid, string>()
                .ForMember(dest => dest, opt => opt.MapFrom(src => src.ToString()));

        }
    }
}
