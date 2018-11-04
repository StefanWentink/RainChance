namespace RainChance.DL.Models
{
    using System;

    public class ValueData<TValue>
        where TValue : IComparable<TValue>
    {
        public TValue Min { get; set; }

        public TValue Max { get; set; }

        public TValue Average { get; set; }

        public TValue Latest { get; set; }

        public TValue Delta { get; set; }

        public int TrendCount { get; set; }

        public TValue LatestTrendDelta { get; set; }

        public bool LatestTrendIncreasing { get; set; }

        public int LatestTrendDuration { get; set; }
    }
}