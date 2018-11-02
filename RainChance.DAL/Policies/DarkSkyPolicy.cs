namespace RainChance.DAL.Policies
{
    using Microsoft.Extensions.Logging;
    using RainChance.DarkSky.Models;
    using SWE.Http.Interfaces;
    using SWE.Polly.Models.Policies;

    public class DarkSkyPolicy : PollyRetryPolicy, ITimeOutPolicy<ResponsePrediction>
    {
        public DarkSkyPolicy(
            ILogger logger)
            : base(logger, 30000, 10000, 10, 1000)
        {
        }
    }
}