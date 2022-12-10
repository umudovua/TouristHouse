using TouristHouse.Application.Dtos.HomeDto;

namespace TouristHouse.Application.Abstractions.Services
{
    public interface IHomeAnnounceService
    {
        Task<ResponseHomeDto> AddAsync(CreateHomeDto createHomeDto);
        Task<ResponseHomeDto> UpdateAsync(UpdateHomeDto updateHomeDto);
        Task<bool> DeleteAsync(string id);
        Task<ResponseHomeDto> GetSingleAsync(string id);
        IQueryable<ResponseHomeDto> GetAll();
    }
}
