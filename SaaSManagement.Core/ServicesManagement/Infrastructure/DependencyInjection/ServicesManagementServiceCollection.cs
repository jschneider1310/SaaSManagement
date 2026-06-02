// Project: SaaSManagement, 01/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using SaaSManagement.Core.CustomerManagement.Domain.Context;
using SaaSManagement.Core.CustomerManagement.Infrastructure.Persistence;

namespace SaaSManagement.Core.ServicesManagement.Infrastructure.DependencyInjection;

/// <summary>
/// Static class that provides the service collection from Service Management
/// </summary>
public static class ServicesManagementServiceCollection
{
    /// <summary>
    /// This method returns all service collections from Service Management.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <returns>A <see cref="IServiceCollection"/> collection</returns>
    public static IServiceCollection AddServicesManagement(
        this IServiceCollection services, string connectionString)
    {
        // ---- DbContext ---------------------------------------------------------------------------------------
        // DbContext with dynamic tenant connection string resolution
        services
            .AddDbContextPool<ICustomerManagementDbContext,
                CustomerManagementDbContext>((serviceProvider, options) =>
                                             {
                                                 options.UseNpgsql(connectionString,
                                                         o =>
                                                         {
                                                             o.MigrationsHistoryTable(
                                                                 tableName:
                                                                 HistoryRepository
                                                                     .DefaultTableName,
                                                                 schema:
                                                                 "ServiceManagement");

                                                             o.EnableRetryOnFailure(
                                                                 maxRetryCount: 3,
                                                                 maxRetryDelay: TimeSpan
                                                                     .FromSeconds(10),
                                                                 errorCodesToAdd: null);

                                                             // Keep connections alive so shared_buffers stays warm per connection
                                                             o.CommandTimeout(30);
                                                         })
                                                     // Compile queries at startup — avoids parse/plan overhead on hot paths
                                                     .UseQueryTrackingBehavior(
                                                         QueryTrackingBehavior
                                                             .NoTrackingWithIdentityResolution);
                                             });

        return services;
    }
}