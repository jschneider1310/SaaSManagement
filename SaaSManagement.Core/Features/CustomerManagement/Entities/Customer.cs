// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.Features.CustomerManagement.Constants;
using SaaSManagement.Core.Features.CustomerManagement.Primitives;
using SaaSManagement.Core.Shared.Abstractions;

namespace SaaSManagement.Core.Features.CustomerManagement.Entities;

public sealed class Customer : AggregateRoot<ClientId>
{
    public new ClientId Id { get; private set; }
    
    
    public override string GetId() => Id;
}