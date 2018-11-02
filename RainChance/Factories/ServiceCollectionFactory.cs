namespace RainChance.Factories
{
    using Microsoft.Extensions.DependencyInjection;

    internal static class ServiceCollectionFactory
    {
        internal static IServiceCollection Create()
        {
            return new ServiceCollection();
        }
    }
}