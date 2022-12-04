using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Domain.Entites
{
    public class City:BaseEntity
    {
        public string Name { get; set; }

        public string CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Village> Villages { get; set; }
    }
}
