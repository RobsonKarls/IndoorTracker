namespace IndoorTracker.Domain.SeedOfWork
{
    public interface IRespository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
