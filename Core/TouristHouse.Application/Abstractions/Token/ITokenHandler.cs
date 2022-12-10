using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Domain.Entites;

namespace TouristHouse.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Task<Models.Token> CreateAccessTokenAsync(AppUser user);
        string CreateRefreshToken();
    }
}
