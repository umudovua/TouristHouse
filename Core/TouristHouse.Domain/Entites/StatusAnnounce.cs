using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Domain.Entites
{
    public class StatusAnnounce:BaseEntity
    {
        // elaveler olacaq
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public AnnounceStatusType AnnounceStatusType { get; set; }
    }


    public enum AnnounceStatusType
    {
        VIP,
        Standard,
        Premium
    }
}
