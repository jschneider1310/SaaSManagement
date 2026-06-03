// Project: SaaSManagement, 02/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSManagement.Core.CustomerManagement.Domain.Entities;
using SaaSManagement.Core.CustomerManagement.Domain.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Infrastructure.Persistence.EntityConfiguration;
/// <summary>
/// Provides entity configuration using <see cref="IEntityTypeConfiguration{TEntity}"/> Configure method.
/// </summary>
internal sealed class BusinessCustomerEntityConfiguration : IEntityTypeConfiguration<BusinessCustomer>
{
    public void Configure(EntityTypeBuilder<BusinessCustomer> builder)
    {
        builder.ToTable("BusinessCustomers");
        builder.Property(b => b.Id)
            .HasConversion(id => id.ToString(), id => new ClientId(id));

        builder.OwnsMany(c => c.Contacts,
            c =>
            {
                c.ToTable("BusinessContacts");
                c.WithOwner().HasForeignKey("ClientId");
                c.HasKey(c => c.ContactId);
                c.Property(c => c.FullName).IsRequired();
                c.Property(c => c.Email).IsRequired();
                c.Property(c => c.PhoneNumber).IsRequired();
                c.Property(c => c.PositionName).IsRequired();
            });

        builder.HasAlternateKey(c => new
                                     {
                                         c.LegalName, 
                                         c.FantasyName,
                                         c.RegistrationNumber
                                     });

        builder.HasIndex(c => new { c.LegalName, c.FantasyName, c.RegistrationNumber });
        builder.HasIndex(c => new { c.LegalName, c.Email, c.PhoneNumber });
    }
}