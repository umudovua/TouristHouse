namespace TouristHouse.Application.Dtos.HomeDto
{
    public class CreateHomeDto
    {
        public string? AnnounceId { get; set; }
        public int FloorCount { get; set; }
        public double Area { get; set; }
        public int RoomCount { get; set; }
        public int BedCount { get; set; }
    }
}
