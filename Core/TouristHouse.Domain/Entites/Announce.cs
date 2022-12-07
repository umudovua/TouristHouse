using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Domain.Entites
{
    public class Announce : BaseEntity
    {
        public Announce()
        {
            SeeCount++;

            var dt = DateTime.Now - CreatedDate;
            IsActive = dt.Days > 30 ? false : true;
        }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        public int FloorCount { get; set; }
        public double Area { get; set; }
        public int RoomCount { get; set; }
        public int BedCont { get; set; }

        public int SeeCount { get; }

        public string? UserId { get; set; }
        public AppUser? User { get; set; }

        public string? CountryId { get; set; }
        public Country? Country { get; set; }
        public string? CityId { get; set; }
        public City? City { get; set; }
        public string? VillageId { get; set; }
        public Village? Village { get; set; }


        public ICollection<Photo>? Photos { get; set; }
        public StatusAnnounce? Status { get; set; }

        public ICollection<AnnounceTag>? AnnounceTags { get; set; }

    }

}
