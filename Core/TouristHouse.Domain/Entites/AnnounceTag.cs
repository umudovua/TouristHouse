using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Domain.Entites
{
    public class AnnounceTag:BaseEntity
    {
        public string Name { get; set; }

        public string AnnounceId { get; set; }
        public Announce Announce { get; set; }
    }
}
