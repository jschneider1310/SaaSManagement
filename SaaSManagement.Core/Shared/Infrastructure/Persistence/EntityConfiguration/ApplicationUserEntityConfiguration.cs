// Project: SaaSManagement, 19/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSManagement.Core.Identity.Implementations;

namespace SaaSManagement.Core.Shared.Infrastructure.Persistence.EntityConfiguration;
/// <summary>
/// Applies configurations for the entity type <see cref="ApplicationUser"/>
/// </summary>
public sealed class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers", "Identity");
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Email);
        builder.HasIndex(e => e.EntityId);
        builder.HasIndex(e => new { e.EntityId, e.UserType });
    }
}