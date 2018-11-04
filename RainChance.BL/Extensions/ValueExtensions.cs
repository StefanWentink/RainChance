namespace RainChance.BL.Extensions
{
    using RainChance.DL.Models;
    using System.Collections.Generic;
    using System.Linq;

    internal static class ValueExtensions
    {
        internal static ValueData<double> ToValueData(this IEnumerable<double> values)
        {
            var min = values.Min();
            var max = values.Max();

            int trendCount = 0;
            double latestTrendDelta = 0;
            bool latestTrendIncreasing = false;
            int latestTrendDuration = 0;

            var lastValue = values.First();
            var lastTrendValue = values.First();

            foreach (var value in values)
            {
                var trendIncreasing = value > lastValue;

                if (trendIncreasing != latestTrendIncreasing)
                {
                    latestTrendIncreasing = trendIncreasing;
                    latestTrendDuration = 0;
                    latestTrendDelta = 0;
                    lastTrendValue = value;
                    trendCount++;
                }

                latestTrendDelta = value - lastTrendValue;

                latestTrendDuration++;
            }

            return new ValueData<double>
            {
                Min = min,
                Max = values.Max(),
                Average = values.Average(),
                Latest = values.LastOrDefault(),
                Delta = max - min,
                TrendCount = trendCount,
                LatestTrendDelta = latestTrendDelta,
                LatestTrendIncreasing = latestTrendIncreasing,
                LatestTrendDuration = latestTrendDuration
            };
        }
    }
}