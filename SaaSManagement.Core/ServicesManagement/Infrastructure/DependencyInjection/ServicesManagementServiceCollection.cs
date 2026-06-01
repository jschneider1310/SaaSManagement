// Project: SaaSManagement, 01/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.Extensions.DependencyInjection;

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
        this IServiceCollection services)
    {
        
        
        return services;
    }
}