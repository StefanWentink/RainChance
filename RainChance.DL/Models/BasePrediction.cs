namespace RainChance.DL.Models
{
    using SWE.Model.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Prediction : IKey
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public DateTimeOffset Time { get; set; }

        public double PrecipIntensity { get; set; }

        public double PrecipProbability { get; set; }

        public double DewPoint { get; set; }

        public double Humidity { get; set; }

        public double Pressure { get; set; }

        public double WindSpeed { get; set; }

        public int WindBearing { get; set; }

        public double CloudCover { get; set; }

        public double UvIndex { get; set; }

        public double Visibility { get; set; }
    }
}