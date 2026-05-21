// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Abstractions;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : ApplicationId
{
}