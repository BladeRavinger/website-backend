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
            //needs to read dbConUrl from configuration
            if (Directory.Exists(Path.Combine(".", "website-backend-config")) && File.Exists(Path.Combine(".", "website-backend-config", "database.json")))
                dbConUrl = File.ReadAllText(Path.Combine(".", "website-backend-config", "database.json"));
            else
            {
                Trace.TraceInformation("Private config not found attempting to use environment variable");
                dbConUrl = Environment.GetEnvironmentVariable("dbConUrl");
            }
        }
    }
}
