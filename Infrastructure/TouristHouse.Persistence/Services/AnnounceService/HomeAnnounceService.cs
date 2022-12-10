using AutoMapper;
using TouristHouse.Application.Abstractions.Services;
using TouristHouse.Application.Dtos.HomeDto;
using TouristHouse.Application.Repositories;
using TouristHouse.Domain.Entites.Category;

namespace TouristHouse.Persistence.Services.AnnounceService
{
    public class HomeAnnounceService : IHomeAnnounceService
    {
        private readonly IMapper _mapper;
        private readonly IHomeAnnounceRepository _homeAnnounceRepository;
        public HomeAnnounceService(IMapper mapper, IHomeAnnounceRepository homeAnnounceRepository)
        {
            _mapper = mapper;
            _homeAnnounceRepository = homeAnnounceRepository;
        }

        public async Task<ResponseHomeDto> AddAsync(CreateHomeDto createHomeDto)
        {
            var model = _mapper.Map<Home>(createHomeDto);
            await _homeAnnounceRepository.AddAsync(model);

            await _homeAnnounceRepository.SaveAsync();

            return _mapper.Map<ResponseHomeDto>(model);
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ResponseHomeDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseHomeDto> GetSingleAsync(string id)
        {
            var dbModel = await _homeAnnounceRepository.GetByIdAsync(id);
            ResponseHomeDto response = _mapper.Map<ResponseHomeDto>(dbModel);

            return response;
        }

        public Task<ResponseHomeDto> UpdateAsync(UpdateHomeDto updateHomeDto)
        {
            throw new NotImplementedException();
        }
    }
}
