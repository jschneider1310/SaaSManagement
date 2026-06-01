// Project: SaaSManagement, 27/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Abstractions.Interfaces;
/// <summary>
/// Interface that represents the DbContext of the application
/// </summary>
public interface IApplicationDbContext
{
    
    /// <summary>
    /// Saves the changes to the database.
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/> object</param>
    /// <returns>Integer with 1 if success and zero otherwise.</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}