using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Domain.Entites.Category
{
    public class Home:BaseEntity
    {
        public string? AnnounceId { get; set; }
        public Announce? Announce { get; set; }

        public int FloorCount { get; set; }
        public double Area { get; set; }
        public int RoomCount { get; set; }
        public int BedCount { get; set; }
    }
}
