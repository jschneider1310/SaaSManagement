// Project: SaaSManagement, 29/05/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using SaaSManagement.Core.CustomerManagement.Infrastructure.Persistence;
using SaaSManagement.Core.Shared.Abstractions.Interfaces;

namespace SaaSManagement.Core.CustomerManagement.Infrastructure.DependencyInjection;

public static class CustomerManagementServiceCollection
{
    public static IServiceCollection AddCustomerManagementServiceCollection(
        this IServiceCollection services, string  connectionString)
    {
        // ---- DbContext ---------------------------------------------------------------------------------------
        // DbContext with dynamic tenant connection string resolution
        services.AddDbContextPool<IApplicationDbContext, CustomerManagementDbContext>((serviceProvider,
            options) =>
        {
            options.UseNpgsql(connectionString,
                    o =>
                    {
                        o.MigrationsHistoryTable(
                            tableName: HistoryRepository.DefaultTableName,
                            schema: "ClientManagement");

                        o.EnableRetryOnFailure(maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorCodesToAdd: null);

                        // Keep connections alive so shared_buffers stays warm per connection
                        o.CommandTimeout(30);
                    })
                // Compile queries at startup — avoids parse/plan overhead on hot paths
                .UseQueryTrackingBehavior(QueryTrackingBehavior
                    .NoTrackingWithIdentityResolution);
        });

        return services;
    }
}