// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Abstractions.Classes;
/// <summary>
/// Abstract class for all entity classes.
/// </summary>
/// <typeparam name="TId">Id type of the entity</typeparam>
public abstract class Entity<TId>
{
    
    
    protected TId Id { get; set; } = default!;
    public DateTime DateCreated { get; } = DateTime.UtcNow;
    public DateTime? DateModified { get; private set; }
    public DateTime? DateDeleted { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsArchived { get; private set; }
    
    
    // Allows import entities with early date creation
        protected Entity(DateTime createdOn)
        {
            DateCreated = createdOn;
        }
        protected Entity() { }
    
    /// <summary>
    /// Returns the Id of an Entity as a string object.
    /// </summary>
    /// <returns>String representing the Id.</returns>
    public abstract string GetId();
    
    /// <summary>
    /// Mark the entity as deleted and updates its DateDeleted and DateUpdated.
    /// </summary>
    public void Delete()
    {
        IsDeleted = true;
        DateDeleted = DateTime.UtcNow;
        Update();
    }
    /// <summary>
    /// Restores an archived entity to its active state.
    /// </summary>
    public void UnArchive()
    {
        IsArchived = false;
        Update();
    }
    /// <summary>
    /// Archives an entity.
    /// </summary>
    public void Archive()
    {
        IsArchived = true;
        Update();
    } 
    /// <summary>
    /// Updates an entity based on the given parameter.
    /// </summary>
    /// <param name="modifiedOn"><see cref="DateTime"/> with the date it was updated.</param>
    public void Update(DateTime modifiedOn) => DateModified = modifiedOn;
    /// <summary>
    /// Updates the entity after every modification with the modification's UTC date and time.
    /// </summary>
    private void Update() => DateModified = DateTime.UtcNow;
}