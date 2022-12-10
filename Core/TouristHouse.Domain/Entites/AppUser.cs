using Microsoft.AspNetCore.Identity;

namespace TouristHouse.Domain.Entites
{
    public class AppUser: IdentityUser
    {
        public string? Name { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public ICollection<Announce>? Announces { get; set; }
    }

    public enum AppRole
    {
        Member,
        Admin,
        Moderator,
        SuperAdmin
    }
}
