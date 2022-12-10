using Microsoft.Extensions.DependencyInjection;
using TouristHouse.Application.Abstractions.Token;
using TouristHouse.Infrastructure.Mapping;
using TouristHouse.Infrastructure.Services.Token;

namespace TouristHouse.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new MappingProfile());
            });

        }
    }
}
