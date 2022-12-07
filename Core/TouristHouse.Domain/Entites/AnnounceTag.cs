using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Domain.Entites
{
    public class AnnounceTag:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Announce> Announces { get; set; }
    }
}
