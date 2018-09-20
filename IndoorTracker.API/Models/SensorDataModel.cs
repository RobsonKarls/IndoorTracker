using System.Collections.Generic;

namespace IndoorTracker.API.Models
{
    public class SensorDataModel
    {
        public string d { get; set; }
        public string f { get; set; }
        public double t { get; set; }
        public string l { get; set; }
        public Sensor s { get; set; }
        public Dictionary<string, string> gps { get; set; }
    }

    public class Sensor
    {
        public Dictionary<string, int> wifi { get; set; }
        public Dictionary<string, int> bluetooth { get; set; }

    }
}
