// Project: SaaSManagement, 27/05/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using SaaSManagement.Core.CustomerManagement.Entities;
using SaaSManagement.Core.ServicesManagement.Domain.Entities;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.Shared.Abstractions.Interfaces;
/// <summary>
/// Interface that represents the DbContext of the application
/// </summary>
public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    DbSet<BusinessCustomer> BusinessCustomers { get; set; }
    DbSet<ServiceLevelAgreement> ServiceLevelAgreements { get; set; }
    DbSet<Address> Addresses { get; set; }
    DbSet<Note> Notes { get; set; }
}