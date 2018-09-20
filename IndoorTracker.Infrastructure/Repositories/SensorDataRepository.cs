using IndoorTracker.Domain.Models.SensorData;
using IndoorTracker.Domain.SeedOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IndoorTracker.Infrastructure.Repositories
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly SensorDataContext _context;

        public SensorDataRepository(SensorDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public SensorData Add(SensorData sensorData)
        {
            if (sensorData.IsTransient())
            {
                return _context.SensorsData.Add(sensorData).Entity;
            }
            else
            {
                return sensorData;
            }
        }

        public async Task<SensorData> GetAsync(int id)
        {
            return await _context.SensorsData.FindAsync(id);
        }
    }
}
