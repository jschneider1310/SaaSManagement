// Project: SaaSManagement, 28/05/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using SaaSManagement.Core.CustomerManagement.Domain.Context;
using SaaSManagement.Core.CustomerManagement.Domain.Entities;
using SaaSManagement.Core.ServicesManagement.Domain.Entities;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Infrastructure.Persistence;

public sealed class CustomerManagementDbContext : DbContext, ICustomerManagementDbContext
{
    public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options) : base(options)
    {
    }

    private CustomerManagementDbContext()
    {
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<BusinessCustomer> BusinessCustomers { get; set; }
    public DbSet<ServiceLevelAgreement> ServiceLevelAgreements { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Note> Notes { get; set; }
}