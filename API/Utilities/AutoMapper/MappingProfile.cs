using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace API.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarrierUpdateDto, Carrier>().ReverseMap();
            CreateMap<Carrier, CarrierDto>().ReverseMap();
            CreateMap<CarrierCreateDto, Carrier>().ReverseMap();

            CreateMap<OrderUpdateDto, Order>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderCreateDto, Order>().ReverseMap();


            CreateMap<CarrierConfigurationUpdateDto, CarrierConfiguration>().ReverseMap();
            CreateMap<CarrierConfiguration, CarrierConfigurationDto>().ReverseMap();
            CreateMap<CarrierConfigurationCreateDto, CarrierConfiguration>().ReverseMap();
        }
    }

}