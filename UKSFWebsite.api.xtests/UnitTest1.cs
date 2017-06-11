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
            Environment.SetEnvironmentVariable("DbConUrl", "example");
            Assert.Equal("example", ConfigManager.getValue("DbConUrl"));
        }

        [Fact]
        public void GetConfigNotFromEnv()
        {
            ConfigManager.getValue("DbConUrl");
            Assert.NotEqual("example", ConfigManager.getValue("DbConUrl"));
        }
    }
}
