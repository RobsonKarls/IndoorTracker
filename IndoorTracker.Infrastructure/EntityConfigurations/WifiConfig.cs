using IndoorTracker.Domain.Models.SensorData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndoorTracker.Infrastructure.EntityConfigurations
{
    public class WifiConfig : IEntityTypeConfiguration<Wifi>
    {
        public void Configure(EntityTypeBuilder<Wifi> builder)
        {
            builder.ToTable("wifis", SensorDataContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RSSI).IsRequired();
            builder.Property(x => x.MacAddress).IsRequired();
        }
    }
}
