using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TouristHouse.Application.Abstractions.Services;
using TouristHouse.Application.Abstractions.Services.User;
using TouristHouse.Application.Models;
using TouristHouse.Application.Repositories;
using TouristHouse.Domain.Entites;
using TouristHouse.Persistence.Context;
using TouristHouse.Persistence.Repositories;
using TouristHouse.Persistence.Services;
using TouristHouse.Persistence.Services.AnnounceService;
using TouristHouse.Persistence.Services.User;

namespace TouristHouse.Persistence
{
    public static class ServiceRegistraton
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("MsSql")));
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;

                opt.User.RequireUniqueEmail = true;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPhotoService, PhotoService>();


            services.AddScoped<IAnnounceRepository, AnnounceRepository>();
            services.AddScoped<IHomeAnnounceRepository, HomeAnnounceRepository>();


            services.AddScoped<IAnnounceService, AnnounceService>();
            services.AddScoped<IHomeAnnounceService, HomeAnnounceService>();
        }






        public static CloudinarySettings GetCloudinarySettings
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/TouristHouse.API"));
                configurationManager.AddJsonFile("appsettings.json");
                CloudinarySettings cloudinary = new()
                {
                    CloudName = configurationManager.GetSection("CloudinarySettings:CloudName").Value,
                    ApiKey = configurationManager.GetSection("CloudinarySettings:ApiKey").Value,
                    ApiSecret = configurationManager.GetSection("CloudinarySettings:ApiSecret").Value,

                };
                return cloudinary;
            }
        }
    }
}
