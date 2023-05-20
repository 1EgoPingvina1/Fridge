using API.DTO;
using API.Models;
using AutoMapper;

namespace API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFridgeDTO, Fridge>();
            CreateMap<CreateFridgeProductDTO, FridgeProduct>();
            CreateMap<Fridge, FridgeDTO>()
                .ForMember(p => p.ModelName, src => src.MapFrom(x => x.Model.Name));
        }
    }
}
