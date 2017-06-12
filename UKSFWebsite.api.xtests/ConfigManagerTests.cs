using System;
using Xunit;
using UKSFWebsite.api.Core;

namespace UKSFWebsite.api.xtests
{
    public class ConfigManagerTests
    {
        [Fact]
        public void GetConfigFromEnv()
        {
            Environment.SetEnvironmentVariable("exampleconfig", "example");
            Assert.Equal("example", ConfigManager.getValue("exampleconfig"));
            Environment.SetEnvironmentVariable("exampleconfig", null);
        }

        [Fact]
        public void GetConfigNotFromEnv()
        {
            Environment.SetEnvironmentVariable("exampleconfig", "notexample");
            Assert.NotEqual("example", ConfigManager.getValue("exampleconfig"));
            Environment.SetEnvironmentVariable("exampleconfig", null);
        }
        /* CI needs to have env variables added for this to not fail their tests
        [Fact]
        public void GetConfigFromFile()
        {
            Assert.Contains("mongodb://api:", ConfigManager.getValue("DbConUrl"));
            Assert.Contains(":27017/UKSF", ConfigManager.getValue("DbConUrl"));
        }

        [Fact]
        public void GetBadConfig()
        {
            Assert.Equal("", ConfigManager.getValue("DbConUrlFake"));
        }
        */
    }
}
