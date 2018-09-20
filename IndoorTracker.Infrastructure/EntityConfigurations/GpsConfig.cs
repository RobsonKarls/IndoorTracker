using IndoorTracker.Domain.Models.SensorData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndoorTracker.Infrastructure.EntityConfigurations
{
    public class GpsConfig : IEntityTypeConfiguration<Gps>
    {
        public void Configure(EntityTypeBuilder<Gps> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("gps", SensorDataContext.DEFAULT_SCHEMA);
            builder.Property(x => x.Altitude).IsRequired();
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();

        }
    }
}
