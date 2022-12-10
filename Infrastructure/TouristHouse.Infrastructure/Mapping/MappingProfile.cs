using AutoMapper;
using TouristHouse.Application.Dtos.AnnounceDto;
using TouristHouse.Application.Dtos.HomeDto;
using TouristHouse.Domain.Entites;
using TouristHouse.Domain.Entites.Category;

namespace TouristHouse.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Home, CreateHomeDto>().ReverseMap();
            CreateMap<Home, ResponseHomeDto>().ReverseMap();
            CreateMap<Home, UpdateHomeDto>().ReverseMap();

            CreateMap<Announce, CreateAnnounceDto>().ReverseMap();
            CreateMap<Announce, ResponseAnnounceDto>().ReverseMap();
            CreateMap<Announce, UpdateAnnounceDto>().ReverseMap();
        }
    }
}
