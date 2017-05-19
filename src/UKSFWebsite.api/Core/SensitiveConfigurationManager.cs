using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace UKSFWebsite.api.Core
{
    public static class SensitiveConfigurationManager
    {
        public static string dbConUrl { get; private set; }

        internal static void Setup(IConfigurationRoot configuration)
        {
            //needs to read dbConUrl from configuration
            dbConUrl = System.IO.File.ReadAllText(".\\website-backend-config\\database.json"); ;
        }
    }
}
