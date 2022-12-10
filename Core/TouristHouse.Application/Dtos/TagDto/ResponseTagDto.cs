using TouristHouse.Application.Dtos.AnnounceDto;

namespace TouristHouse.Application.Dtos.TagDto
{
    public class ResponseTagDto
    {
        public string? Name { get; set; }
        public ICollection<ResponseAnnounceDto>? AnnounceDtos { get; set; }
    }
}
