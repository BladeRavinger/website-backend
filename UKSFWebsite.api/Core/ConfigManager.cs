using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UKSFWebsite.api.Core
{
    public static class ConfigManager
    {

        internal static void Setup(IConfigurationRoot configuration)
        {
        }

        public static string getValue(string key)
        {
            string value;

            value = Environment.GetEnvironmentVariable(key);

            if (value == null)
                value = getFromFile(key);

            return value;
        }

        private static string getFromFile(string key)
        {
            //return File.ReadAllText(Path.Combine("website-backend-config", "database.json"));
            //TODO: stubbed...load from root path and json
            return "";
        }
    }
}
