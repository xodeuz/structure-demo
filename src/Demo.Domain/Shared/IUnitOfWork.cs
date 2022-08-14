namespace Demo.Domain.Shared;

/// <summary>
///     Unit of work abstraction
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     Save pending changes
    /// </summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
