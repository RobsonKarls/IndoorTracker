using IndoorTracker.Domain.SeedOfWork;
using System.Threading.Tasks;

namespace IndoorTracker.Domain.Models.SensorData
{
    public interface ISensorDataRepository : IRespository<SensorData>
    {
        SensorData Add(SensorData sensorData);
        Task<SensorData> GetAsync(int id);
    }
}
