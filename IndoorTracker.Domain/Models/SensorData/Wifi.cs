using IndoorTracker.Domain.SeedOfWork;

namespace IndoorTracker.Domain.Models.SensorData
{
    public class Wifi : Entity
    {
        public string MacAddress { get; set; }
        public int RSSI { get; set; }
    }
}
