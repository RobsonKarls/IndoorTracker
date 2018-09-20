using IndoorTracker.Domain.Models.SensorData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndoorTracker.Infrastructure.EntityConfigurations
{
    public class SensorDataConfig : IEntityTypeConfiguration<SensorData>
    {
        public void Configure(EntityTypeBuilder<SensorData> sensorConfig)
        {
            sensorConfig.HasKey(x => x.Id);
            sensorConfig.ToTable("sensorsData", SensorDataContext.DEFAULT_SCHEMA);
            sensorConfig.Property(b => b.Id).ForSqlServerUseSequenceHiLo("sensorDataseq", SensorDataContext.DEFAULT_SCHEMA);
            sensorConfig.Property(x => x.Device).IsRequired();
            sensorConfig.Property(x => x.Family).IsRequired();
            sensorConfig.Property(x => x.Date).IsRequired();
            sensorConfig.HasMany(x => x.Wifis).WithOne().HasForeignKey("SensorDataId").OnDelete(DeleteBehavior.Cascade);
            sensorConfig.HasOne(x => x.GPS);
            sensorConfig.Ignore(x => x.Bluetooths);
        }
    }
}
