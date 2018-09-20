using System;
using System.Threading;
using System.Threading.Tasks;

namespace IndoorTracker.Domain.SeedOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
