using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Domain.Entites
{
    public class Photo:BaseEntity
    {
        public string? ImageUrl { get; set; }
        public string? ImagePublicId { get; set; }

        public bool IsMain { get; set; }

        public string AnnounceId { get; set; }
        public Announce Announce { get; set; }

    }
}
