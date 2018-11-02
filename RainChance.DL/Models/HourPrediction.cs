namespace RainChance.DL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HourPrediction : Prediction
    {
        [Required]
        public Guid DayPredictionId { get; set; }

        public double Temperature { get; set; }

        public double ApparentTemperature { get; set; }

        [ForeignKey(nameof(DayPredictionId))]
        public DayPrediction DayPrediction { get; set; }
    }
}