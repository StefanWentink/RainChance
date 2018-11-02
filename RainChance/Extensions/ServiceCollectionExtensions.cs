namespace RainChance.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using RainChance.DAL.Models;
    using RainChance.DAL.Policies;
    using RainChance.DarkSky.Models;
    using SWE.Http.Interfaces;
    using SWE.Polly.Models;
    using System;

    internal static class ServiceCollectionExtensions
    {
        internal static IServiceProvider LoadDependancies(this IServiceCollection serviceCollection, ILogger logger)
        {
            return serviceCollection
                .AddLogging()
                    .AddSingleton(logger)
                    .AddTransient<IExchanger, PolicyExchanger>()
                    .AddTransient<IUriContainer, DarkSkyUriContainer>()
                    //.AddTransient<IBatchContainer, BatchContainer>();
                    .AddTransient<IRepository<ResponsePrediction>, DarkSkyRepository>()
                    .AddTransient<ITimeOutPolicy<ResponsePrediction>, DarkSkyPolicy>()
                    .AddTransient<IActions, DarkSkyActions>()
                    .BuildServiceProvider();
        }
    }
}