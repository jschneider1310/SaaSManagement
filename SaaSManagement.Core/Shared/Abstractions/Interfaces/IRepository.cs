// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.Linq.Expressions;
using SaaSManagement.Core.ServicesManagement.Domain.Primitives;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Common;

namespace SaaSManagement.Core.Shared.Abstractions.Interfaces;
/// <summary>
/// Generic Interface for implementing specific repositories.
/// <remarks>
/// For aggregate root enforcement all entity Ids inherit from <see cref="Classes.ApplicationId"/>.
/// The specific Ids are created for clarity and/or for specific conventions on its creation. E.g.:
/// When an Id must contain a certain pattern like <see cref="SlaId"/>
/// </remarks>
/// </summary>
/// <typeparam name="T">Entity Type</typeparam>
/// <typeparam name="TId">Entity Id Type</typeparam>
public interface IRepository<T, TId> where T : Entity<TId>
{
    /// <summary>
    /// Adds a new entity T
    /// </summary>
    /// <param name="entity">Entity of type T</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>T</returns>
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Adds a <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="entities">T entity</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Result"/> with a list of T entities</returns>
    Task<Result<List<T>>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a T entity
    /// </summary>
    /// <param name="entity">T</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Updated T entity</returns>
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a list of T entities
    /// </summary>
    /// <param name="entities"><see cref="IEnumerable{T}"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>The updated List of T entities inside a <see cref="Result"/> object.</returns>
    Task<Result<List<T>>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a given T entity
    /// </summary>
    /// <param name="entity">T</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>True if the operation succeed, and false otherwise.</returns>
    Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a given T entity based on its given TId
    /// </summary>
    /// <param name="entityId">TId type</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>True if the entity was successful deleted, and false otherwise.</returns>
    Task<bool> DeleteAsync(TId entityId, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a range of T entities
    /// </summary>
    /// <param name="entities"><see cref="IEnumerable{T}"/> of T entities</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>True if the operation succeed, and false otherwise.</returns>
    Task<bool> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a list with all T entities inside a <see cref="Result"/> object.
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Result"/> with an <see cref="IEnumerable{T}"/> of T entities.</returns>
    Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a list with all T entities that satisfy the given predicate.
    /// </summary>
    /// <param name="predicate">Expression with the search parameters.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Result"/> with an <see cref="IEnumerable{T}"/> of T entities that satisfy the predicate</returns>
    Task<Result<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}