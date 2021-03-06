﻿namespace RainChance.DL.Interfaces
{
    using SWE.Model.Interfaces;
    using System;

    public interface IPrediction : IKey
    {
        DateTimeOffset Time { get; set; }

        double PrecipIntensity { get; set; }

        double PrecipProbability { get; set; }

        double DewPoint { get; set; }

        double Humidity { get; set; }

        double Pressure { get; set; }

        double WindSpeed { get; set; }

        int WindBearing { get; set; }

        double CloudCover { get; set; }

        double UvIndex { get; set; }

        double Visibility { get; set; }
    }
}