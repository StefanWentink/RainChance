namespace RainChance.DAL.Models
{
    using SWE.Http.Constants;
    using SWE.Http.Models;

    public class DarkSkyUriContainer : UriContainer
    {
        public DarkSkyUriContainer()
            : this("https://api.darksky.net")
        {
        }

        public DarkSkyUriContainer(string uri)
            : base(uri, "forecast", ExchangerConstants.ContentType, "/")
        {
        }
    }
}