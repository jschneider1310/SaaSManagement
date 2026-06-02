// Project: SaaSManagement, 02/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSManagement.Core.CustomerManagement.Domain.Constants;
using SaaSManagement.Core.CustomerManagement.Domain.Entities;

namespace SaaSManagement.Core.CustomerManagement.Infrastructure.Persistence.EntityConfiguration;

internal sealed class IndividualCustomerEntityConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable("IndividualCustomers");
        builder.Property(c => c.FirstName)
            .HasMaxLength(CustomerManagementConstants.MaximumNameLength)
            .IsRequired();
        builder.Property(c => c.LastName)
            .HasMaxLength(CustomerManagementConstants.MaximumNameLength)
            .IsRequired();
        builder.Property(c => c.BirthDate).IsRequired();
        
        builder.HasAlternateKey(c => new {c.FirstName, c.LastName, c.BirthDate}); // Uniqueness for individual clients.
        
        builder.HasIndex(c => c.FirstName)
            .IncludeProperties(c => new {c.LastName, c.BirthDate, c.PhoneNumber, c.Email});
    }
}