namespace RainChance.DAL.Builders
{
    using RainChance.DarkSky.Models;
    using RainChance.DL.Models;
    using SWE.BasicType.Date.Utilities;

    public class DayPredictionBuilder : BasePredictionBuilder<DayPrediction, DailyPrediction>
    {
        public DayPredictionBuilder(DailyPrediction member)
            : base(member)
        {
        }

        protected override DayPrediction BuildResult()
        {
            var result = base.BuildResult();

            result.SunriseTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.SunriseTime, OffsetSeconds);
            result.SunsetTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.SunsetTime, OffsetSeconds);
            result.MoonPhase = Member.MoonPhase;
            result.PrecipIntensityMax = Member.PrecipIntensityMax;
            result.PrecipIntensityMaxTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.PrecipIntensityMaxTime, OffsetSeconds);
            result.PrecipAccumulation = Member.PrecipAccumulation;
            result.PrecipType = Member.PrecipType;
            result.TemperatureHigh = Member.TemperatureHigh;
            result.TemperatureHighTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.TemperatureHighTime, OffsetSeconds);
            result.TemperatureLow = Member.TemperatureLow;
            result.TemperatureLowTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.TemperatureLowTime, OffsetSeconds);
            result.ApparentTemperatureHigh = Member.ApparentTemperatureHigh;
            result.ApparentTemperatureHighTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.ApparentTemperatureHighTime, OffsetSeconds);
            result.ApparentTemperatureLow = Member.ApparentTemperatureLow;
            result.ApparentTemperatureLowTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.ApparentTemperatureLowTime, OffsetSeconds);
            result.UvIndexTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.UvIndexTime, OffsetSeconds);
            result.TemperatureMin = Member.TemperatureMin;
            result.TemperatureMinTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.TemperatureMinTime, OffsetSeconds);
            result.TemperatureMax = Member.TemperatureMax;
            result.TemperatureMaxTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.TemperatureMaxTime, OffsetSeconds);
            result.ApparentTemperatureMin = Member.ApparentTemperatureMin;
            result.ApparentTemperatureMinTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.ApparentTemperatureMinTime, OffsetSeconds);
            result.ApparentTemperatureMax = Member.ApparentTemperatureMax;
            result.ApparentTemperatureMaxTime = ConversionUtilities.UnixTimeStampToDateTimeOffset(Member.ApparentTemperatureMaxTime, OffsetSeconds);

            return result;
        }
    }
}