using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            string fileContents = File.ReadAllText("C:\\website-backend-config\\database.json");
            //TODO: stubbed...load from root path and json
            
            JObject configObj = JObject.Parse(fileContents);
            configObj.TryGetValue(key, out JToken value );
            if (value != null)
                return value.ToString();
            else
                return "";///problem here
        }
    }
}
