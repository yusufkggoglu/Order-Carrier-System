using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace WebApplication.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarrierUpdateDto, Carrier>().ReverseMap();
            CreateMap<Carrier, CarrierDto>().ReverseMap();
            CreateMap<CarrierCreateDto, Carrier>().ReverseMap();
        }
    }
}
