using TouristHouse.Application.Dtos.HomeDto;
using TouristHouse.Domain.Entites;
using TouristHouse.Domain.Entites.Category;

namespace TouristHouse.Application.Dtos.AnnounceDto
{
    public class ResponseAnnounceDto
    {
        public string? Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        public int SeeCount { get; }

        public string? UserId { get; set; }
        public AppUser? User { get; set; }

        public string? HomeId { get; set; }
        public ResponseHomeDto? Home { get; set; }

        public string? CountryId { get; set; }
        //public Country? Country { get; set; }
        public string? CityId { get; set; }
        //public City? City { get; set; }
        public string? VillageId { get; set; }
        //public Village? Village { get; set; }

        public AnnounceCategory Category { get; set; }
        public ICollection<Photo>? Photos { get; set; }
        public StatusAnnounce? Status { get; set; }

        public ICollection<AnnounceTag>? AnnounceTags { get; set; }
    }
}
