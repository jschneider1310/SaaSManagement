// Project: SaaSManagement, 19/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using SaaSManagement.Core.Shared.Abstractions.Interfaces;
using SaaSManagement.Core.Shared.Infrastructure.Persistence;

namespace SaaSManagement.Core.Shared.Infrastructure.ServiceCollectionRegistration;

public static class InfrastructureServiceCollectionRegistration
{
    public static IServiceCollection AddInfrastructureDbContextServices(
        this IServiceCollection services)
    {
        // DbContext registration: First register as concrete type for Identity's AddEntityFrameworkStores
        // then register the interface wrapper
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
                                                    {
                                                        options.UseNpgsql( o =>
                                                        {
                                                            o.MigrationsHistoryTable(
                                                                tableName: HistoryRepository.DefaultTableName,
                                                                schema: "Identity");
                                                            o.EnableRetryOnFailure(
                                                                maxRetryCount: 3,
                                                                maxRetryDelay: TimeSpan.FromSeconds(15),
                                                                errorCodesToAdd: null);
                                                        });
                                                    });

        // Register the interface as a wrapper around the concrete DbContext
        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
        return services;
    }
}