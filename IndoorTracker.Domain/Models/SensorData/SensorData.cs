using IndoorTracker.Domain.SeedOfWork;
using System;
using System.Collections.Generic;

namespace IndoorTracker.Domain.Models.SensorData
{
    public class SensorData : Entity, IAggregateRoot
    {
        public string Device { get; set; }
        public string Family { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Wifi> Wifis { get; set; }
        public IEnumerable<Bluetooth> Bluetooths { get; set; }
        public Gps GPS { get; set; }
    }
}
