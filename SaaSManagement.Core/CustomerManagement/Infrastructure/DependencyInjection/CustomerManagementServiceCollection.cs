// Project: SaaSManagement, 29/05/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using SaaSManagement.Core.CustomerManagement.Domain.Context;
using SaaSManagement.Core.CustomerManagement.Infrastructure.Persistence;

namespace SaaSManagement.Core.CustomerManagement.Infrastructure.DependencyInjection;
/// <summary>
/// Static class for registering the services from Customer Management.
/// </summary>
public static class CustomerManagementServiceCollection
{
    /// <summary>
    /// Registers the <see cref="IServiceCollection"/> services used by the Customer
    /// Management, including the DbContext.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="connectionString">String with the connection string</param>
    /// <returns>The <see cref="IServiceCollection"/> collection.</returns>
    public static IServiceCollection AddCustomerManagementServiceCollection(
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
                                                                 "CustomerManagement");

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