using TouristHouse.Application.Dtos.AnnounceDto;

namespace TouristHouse.Application.Dtos.HomeDto
{
    public class ResponseHomeDto
    {
        public string? Id { get; set; }
        //public ResponseAnnounceDto? Announce { get; set; }
        public string? AnnounceId { get; set; }
        public int FloorCount { get; set; }
        public double Area { get; set; }
        public int RoomCount { get; set; }
        public int BedCount { get; set; }
    }
}
