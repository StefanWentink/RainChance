namespace RainChance.DAL.Policies
{
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using RainChance.DarkSky.Models;
    using SWE.Http.Interfaces;
    using SWE.Http.Models;
    using System.Collections.Generic;

    public class DarkSkyRepository : TypedRepository<ResponsePrediction>
    {
        public DarkSkyRepository(
            ILogger logger,
            IExchanger exchanger,
            IActions actions,
            ITimeOutPolicy<ResponsePrediction> policy)
            : base(logger, exchanger, actions, policy)
        {
        }

        protected override List<ResponsePrediction> Deserialize(string value)
        {
            return new List<ResponsePrediction> {
                JsonConvert.DeserializeObject<ResponsePrediction>(value)
            };
        }
    }
}