using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UKSFWebsite.api.Core
{
    public static class SensitiveConfigurationManager
    {
        public static string dbConUrl { get; private set; }
        
        internal static void Setup(IConfigurationRoot configuration)
        {
            dbConUrl = Environment.GetEnvironmentVariable("dbConUrl");

            if (!(dbConUrl == null))
                dbConUrl = getFromFile("dbConUrl");

        }

        private static string getFromFile(string key)
        {
            //return File.ReadAllText(Path.Combine("website-backend-config", "database.json"));
            //TODO: stubbed...load from root path and json
            return "";
        }
    }
}
