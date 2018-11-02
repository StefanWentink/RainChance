namespace RainChance.DAL.Context
{
    using Microsoft.EntityFrameworkCore;
    using RainChance.DL.Models;
    using System.Linq;

    public class RainChanceContext : DbContext
    {
        private string ConnectionString { get; }

        public RainChanceContext()
            : this("data source=DESKTOP-VJ9ESHG\\SQLEXPRESS;Database=RainChance;Persist Security Info=True;Integrated Security=SSPI;MultipleActiveResultSets=true;")
        {
        }

        public RainChanceContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                ConnectionString,
                o =>
                {
                    o.CommandTimeout(30);
                    o.EnableRetryOnFailure();
                });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DayPrediction
            modelBuilder.Entity<DayPrediction>()
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<DayPrediction>()
                .HasMany(x => x.HourPredictions)
                .WithOne(x => x.DayPrediction)
                .HasForeignKey(x => x.DayPredictionId);

            // HourPrediction
            modelBuilder.Entity<HourPrediction>().HasKey(x => new { x.Id });

            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<DayPrediction> DayPrediction { get; set; }

        public DbSet<HourPrediction> HourPrediction { get; set; }
    }
}