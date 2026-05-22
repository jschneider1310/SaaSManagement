// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.CustomerManagement.Primitives;
using SaaSManagement.Core.Shared.Abstractions;
using SaaSManagement.Core.Shared.Abstractions.Classes;

namespace SaaSManagement.Core.CustomerManagement.Entities;

public class Customer : AggregateRoot<ClientId>
{
    public new ClientId Id { get; private set; }
    
    
    public override string GetId() => Id;
}