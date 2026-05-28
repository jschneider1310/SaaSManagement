// Project: SaaSManagement, 28/05/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using SaaSManagement.Core.CustomerManagement.Entities;
using SaaSManagement.Core.ServicesManagement.Domain.Entities;
using SaaSManagement.Core.Shared.Abstractions.Interfaces;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Infrastructure.Persistence;

public sealed class ApplicationDbContext : IApplicationDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<BusinessCustomer> BusinessCustomers { get; set; }
    public DbSet<ServiceLevelAgreement> ServiceLevelAgreements { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ClientHistory> ClientHistories { get; set; }
    public DbSet<Note> Notes { get; set; }
}