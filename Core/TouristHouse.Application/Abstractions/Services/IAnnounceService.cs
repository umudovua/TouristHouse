using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Application.Dtos.AnnounceDto;

namespace TouristHouse.Application.Abstractions.Services
{
    public interface IAnnounceService
    {
        Task<ResponseAnnounceDto> AddAsync(CreateAnnounceDto createAnnounceDto);
        Task<ResponseAnnounceDto> UpdateAsync(UpdateAnnounceDto updateAnnounce);
        Task<bool> DeleteAsync(string id);
        Task<ResponseAnnounceDto> GetSingleAsync(string id);
        IQueryable<ResponseAnnounceDto> GetAll();
    }
}
