using AutoMapper;
using TouristHouse.Application.Abstractions.Services;
using TouristHouse.Application.Dtos.AnnounceDto;
using TouristHouse.Application.Repositories;
using TouristHouse.Domain.Entites;

namespace TouristHouse.Persistence.Services.AnnounceService
{
    public class AnnounceService : IAnnounceService
    {
        private readonly IMapper _mapper;
        private readonly IAnnounceRepository _announceRepository;
        private readonly IHomeAnnounceService _homeAnnounceService;
        public AnnounceService(IMapper mapper, IAnnounceRepository announceRepository, IHomeAnnounceService homeAnnounceService)
        {
            _mapper = mapper;
            _announceRepository = announceRepository;
            _homeAnnounceService = homeAnnounceService;
        }

        public async Task<ResponseAnnounceDto> AddAsync(CreateAnnounceDto createAnnounceDto)
        {
            var model = _mapper.Map<Announce>(createAnnounceDto);
            model.EndDate = DateTime.Now.AddMonths(12);
            
            switch (createAnnounceDto.Category)
            {
                case AnnounceCategory.Home:
                    createAnnounceDto.HomeDto.AnnounceId = model.Id;
                    var response= await _homeAnnounceService.AddAsync(createAnnounceDto.HomeDto);
                    model.HomeId = response.Id;
                    break;
                case AnnounceCategory.Hotel:
                    break;
                default:
                    break;
            }

            await _announceRepository.AddAsync(model);
            await _announceRepository.SaveAsync();

            return _mapper.Map<ResponseAnnounceDto>(model);
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ResponseAnnounceDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseAnnounceDto> GetSingleAsync(string id)
        {
            var dbModel = await _announceRepository.GetByIdAsync(id);
            if (dbModel != null) dbModel.SeeCount++;
            return _mapper.Map<ResponseAnnounceDto>(dbModel);
        }

        public Task<ResponseAnnounceDto> UpdateAsync(UpdateAnnounceDto updateAnnounce)
        {
            throw new NotImplementedException();
        }
    }
}
