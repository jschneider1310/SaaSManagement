// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.CustomerManagement.Primitives;
using SaaSManagement.Core.Shared.Abstractions;
using SaaSManagement.Core.Shared.Abstractions.Classes;

namespace SaaSManagement.Core.CustomerManagement.Entities;
/// <summary>
/// Represents a Customer into the system. It is the aggregate root for different
/// types of customers (<see cref="IndividualCustomer"/> and <see cref="BusinessCustomer"/>).
/// Here we placed all common fields for a customer, leaving the specific implementations
/// of each type for its own responsibility.
/// </summary>
public class Customer : AggregateRoot<ClientId>
{
    public new ClientId Id { get; private set; }
    
    
    
    public override string GetId() => Id;
}