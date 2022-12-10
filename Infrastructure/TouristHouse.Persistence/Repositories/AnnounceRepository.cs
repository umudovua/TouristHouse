using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Application.Repositories;
using TouristHouse.Domain.Entites;
using TouristHouse.Persistence.Context;

namespace TouristHouse.Persistence.Repositories
{
    public class AnnounceRepository : Repository<Announce>, IAnnounceRepository
    {
        public AnnounceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
