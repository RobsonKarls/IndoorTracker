using IndoorTracker.Domain.Models.SensorData;
using IndoorTracker.Domain.SeedOfWork;
using IndoorTracker.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IndoorTracker.Infrastructure
{
    public class SensorDataContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "tracking";
        public DbSet<SensorData> SensorsData { get; set; }
        public DbSet<Wifi> Wifis { get; set; }
        public DbSet<Gps> Gps { get; set; }

        public SensorDataContext(DbContextOptions<SensorDataContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
            modelBuilder.ApplyConfiguration(new WifiConfig());
            modelBuilder.ApplyConfiguration(new SensorDataConfig());
            modelBuilder.ApplyConfiguration(new GpsConfig());
        }
    }

    public class OrderingContextDesignFactory : IDesignTimeDbContextFactory<SensorDataContext>
    {
        SensorDataContext IDesignTimeDbContextFactory<SensorDataContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SensorDataContext>()
                .UseSqlServer("Server=localhost;User ID=sa;Password=<YourStrong!Passw0rd>;Initial Catalog=TrackingDB;", b => b.MigrationsAssembly("IndoorTracker.API"));

            return new SensorDataContext(optionsBuilder.Options);
        }
    }
}
