using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Application.Repositories;
using TouristHouse.Domain.Entites.Category;
using TouristHouse.Persistence.Context;

namespace TouristHouse.Persistence.Repositories
{
    public class HomeAnnounceRepository : Repository<Home>, IHomeAnnounceRepository
    {
        public HomeAnnounceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
