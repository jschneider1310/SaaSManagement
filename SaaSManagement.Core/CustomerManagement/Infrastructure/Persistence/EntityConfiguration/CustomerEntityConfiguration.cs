// Project: SaaSManagement, 02/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSManagement.Core.CustomerManagement.Domain.Entities;
using SaaSManagement.Core.CustomerManagement.Domain.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Infrastructure.Persistence.EntityConfiguration;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasConversion(id => id.ToString(),
                id => new ClientId(id));

        builder.OwnsMany(c => c.Addresses,
            a =>
            {
                a.ToTable("CustomerAddresses");
                a.WithOwner().HasForeignKey("CustomerId");
                a.HasKey("Id");
                a.Property(x => x.AddressLine1)
                    .IsRequired();

                a.Property(x => x.AddressLine2)
                    .IsRequired();

                a.Property(x => x.City).IsRequired();
                a.Property(x => x.Country).IsRequired();
                a.Property(x => x.PostalCode).IsRequired();
            });

        builder.OwnsMany(c => c.Notes,
            n =>
            {
                n.ToTable("CustomerNotes");
                n.WithOwner().HasForeignKey("ClientId");
                n.HasKey("NoteId");
                n.Property(x => x.Title).IsRequired();
                n.Property(x => x.Content).IsRequired();
                                                    
            });

        builder.HasDiscriminator<string>("CustomerType")
            .HasValue<IndividualCustomer>("Individual")
            .HasValue<BusinessCustomer>("Business");
    }
}