using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TouristHouse.Domain.Entites;
using TouristHouse.Domain.Entites.Category;
using TouristHouse.Domain.Entites.Common;

namespace TouristHouse.Persistence.Context
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Announce> Announces { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<AnnounceTag> AnnounceTags { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<StatusAnnounce> StatusAnnounces { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Village> Villages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Announce>()
                    .HasOne(x => x.Home)
                    .WithOne(x => x.Announce)
                    .HasForeignKey<Home>(x => x.AnnounceId);
            builder.Entity<Home>()
                    .HasOne(x => x.Announce)
                    .WithOne(x => x.Home)
                    .HasForeignKey<Announce>(x => x.HomeId);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
