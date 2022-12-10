using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristHouse.Infrastructure
{
    public class Configuration
    {
        public static string GetSecretKey
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/TouristHouse.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetSection("TokenKey").Value;
            }
        }
    }
}
