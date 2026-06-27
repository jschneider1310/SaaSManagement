// Project: SaaSManagement, 19/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SaaSManagement.Core.Identity.Implementations;
using SaaSManagement.Core.Shared.Abstractions.Interfaces;

namespace SaaSManagement.Core.Shared.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string,
    IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    private ApplicationDbContext() // for tooling/EF
    {
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await Database.BeginTransactionAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUserClaim<string>>(b => { b.ToTable("UserClaims", "Identity"); });

        builder.Entity<IdentityUserLogin<string>>(b => { b.ToTable("UserLogins", "Identity"); });

        builder.Entity<IdentityUserToken<string>>(b => { b.ToTable("UserTokens", "Identity"); });

        builder.Entity<IdentityRole>(b => { b.ToTable("Roles", "Identity"); });

        builder.Entity<IdentityRoleClaim<string>>(b => { b.ToTable("RoleClaims", "Identity"); });

        builder.Entity<IdentityUserRole<string>>(b => { b.ToTable("UserRoles", "Identity"); });
    }
}