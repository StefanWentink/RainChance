namespace RainChance.DAL.Models
{
    using RainChance.DAL.Interfaces;
    using SWE.BasicType.Date.Utilities;
    using System;

    public class DarkSkyParams : IDarkSkyParams
    {
        public string ApiKey { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public double Time { get; }

        public DarkSkyParams(
            string apiKey,
            double latitude,
            double longitude,
            DateTimeOffset time)
            : this(
                  apiKey,
                  latitude,
                  longitude,
                  ConversionUtilities.DateTimeOffsetToUnixTimeStamp(time))
        {
        }

        public DarkSkyParams(
            string apiKey,
            double latitude,
            double longitude,
            double time)
        {
            ApiKey = apiKey;
            Latitude = latitude;
            Longitude = longitude;
            Time = time;
        }
    }
}