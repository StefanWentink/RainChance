namespace RainChance.DAL.Builders
{
    using RainChance.DarkSky.Models;
    using RainChance.DL.Models;
    using SWE.BasicType.Date.Utilities;
    using SWE.Builder.Models;
    using System;

    public abstract class BasePredictionBuilder<TOut, TIn> : Builder<TOut, TIn>
        where TOut : Prediction, new()
        where TIn : BasePrediction
    {
        protected TIn Member { get; private set; }

        protected int OffsetSeconds { get; set; }

        public BasePredictionBuilder(TIn member)
        {
            Member = member;
        }

        public virtual BasePredictionBuilder<TOut, TIn> SetMember(TIn member)
        {
            Member = member;
            return this;
        }

        public virtual BasePredictionBuilder<TOut, TIn> SetOffsetHours(double value)
        {
            OffsetSeconds = (int)Math.Round(value * 3600);
            return this;
        }

        protected override TOut BuildResult()
        {
            return new TOut
            {
                Id = Guid.NewGuid(),
                Time = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.Time, OffsetSeconds),
                PrecipIntensity = Member.PrecipIntensity,
                PrecipProbability = Member.PrecipProbability,
                DewPoint = Member.DewPoint,
                Humidity = Member.Humidity,
                Pressure = Member.Pressure,
                WindSpeed = Member.WindSpeed,
                WindBearing = Member.WindBearing,
                CloudCover = Member.CloudCover,
                UvIndex = Member.UvIndex,
                Visibility = Member.Visibility
            };
        }
    }
}