using TouristHouse.Persistence;

namespace TouristHouse.MVC.Extensions
{
    public static class AppServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services, IConfiguration config)
        {
            services.AddPersistenceServices(config);

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
    }
}
