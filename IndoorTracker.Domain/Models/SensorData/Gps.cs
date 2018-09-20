using IndoorTracker.Domain.SeedOfWork;

namespace IndoorTracker.Domain.Models.SensorData
{
    public class Gps : Entity
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Altitude { get; set; }
    }
}
