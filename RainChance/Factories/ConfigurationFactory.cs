namespace RainChance.Factories
{
    using Microsoft.Extensions.Configuration;
    using System.IO;

    internal static class ConfigurationFactory
    {
        internal static IConfigurationRoot Create()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}