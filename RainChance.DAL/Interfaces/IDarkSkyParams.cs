namespace RainChance.DAL.Interfaces
{
    public interface IDarkSkyParams
    {
        string ApiKey { get; }

        double Latitude { get; }

        double Longitude { get; }

        double Time { get; }
    }
}