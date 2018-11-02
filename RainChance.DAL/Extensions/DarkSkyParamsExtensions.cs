namespace RainChance.DAL.Extensions
{
    using RainChance.DAL.Interfaces;
    using System.Text;

    public static class DarkSkyParamsExtensions
    {
        public static string FormatUri(this IDarkSkyParams darkSkyParams)
        {
            var result = new StringBuilder();

            result.Append(darkSkyParams.ApiKey);
            result.Append("/");
            result.Append(darkSkyParams.Latitude.ToString("0.#####").Replace(',', '.'));
            result.Append(",");
            result.Append(darkSkyParams.Longitude.ToString("0.#####").Replace(',', '.'));
            result.Append(",");
            result.Append(darkSkyParams.Time);
            result.Append("?exclude=currently,flags");

            return result.ToString();
        }
    }
}