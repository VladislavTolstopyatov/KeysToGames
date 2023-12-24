using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.Service.UnitTests.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }
    }
}
