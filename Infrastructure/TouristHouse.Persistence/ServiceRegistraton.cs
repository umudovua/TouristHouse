using Infobip.Api.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristHouse.Application.Models;
using TouristHouse.Domain.Entites;
using TouristHouse.Persistence.Context;

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
        }

        public static CloudinarySettings GetCloudinarySettings
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/TouristHouse.MVC"));
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
