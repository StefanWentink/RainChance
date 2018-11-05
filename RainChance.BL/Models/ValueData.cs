namespace RainChance.DL.Models
{
    using System;

    public class ValueData<TValue>
        where TValue : IComparable<TValue>
    {
        public int Count { get; set; }

        public TValue Min { get; set; }

        public TValue Max { get; set; }

        public TValue Average { get; set; }

        public TValue Latest { get; set; }

        public TValue Delta { get; set; }

        public int TrendSwitches { get; set; }

        public TValue TrendDelta { get; set; }

        public bool TrendIncreasing { get; set; }

        public int TrendDuration { get; set; }
    }
}