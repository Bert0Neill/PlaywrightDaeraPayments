using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightEnd2EndTests.Base_Class
{
    internal class GlobalTestsInitialise
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.dev.json")
                .Build();
            return config;
        }
    }
}
