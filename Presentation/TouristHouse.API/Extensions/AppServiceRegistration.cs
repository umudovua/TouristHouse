using TouristHouse.Application;
using TouristHouse.Infrastructure;
using TouristHouse.Persistence;

namespace TouristHouse.API.Extensions
{
    public static class AppServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services, IConfiguration config)
        {
            services.AddPersistenceServices(config);
            services.AddInfrastructureServices();
            services.AddApplicationServices();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
    }
}
