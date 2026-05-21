// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.CustomerManagement.Entities;
using SaaSManagement.Core.CustomerManagement.Primitives;
using SaaSManagement.Core.Shared.Abstractions.Interfaces;

namespace SaaSManagement.Core.CustomerManagement.Repository;

public interface ICustomerManagementRepository : IRepository<Customer, ClientId>
{
    
}