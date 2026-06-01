// Project: SaaSManagement, 01/06/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.Extensions.DependencyInjection;
using SaaSManagement.Core.Shared.Abstractions.Interfaces;
using Scrutor;

namespace SaaSManagement.Core.Shared.CommonRegistration;
/// <summary>
/// Static class responsible for registering the <see cref="IQueryHandler{TQuery,TResponse}"/>
/// and <see cref="ICommandHandler{TCommand}"/> implementations.
/// </summary>
public static class HandlersRegistration
{
    /// <summary>
    /// Registers all QueryHandlers and CommandHandlers within the assembly.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <returns>A collection of <see cref="IServiceCollection"/> services.</returns>
    public static IServiceCollection RegisterCommandAndQueryHandlers(
        this IServiceCollection services)
    {
        services.Scan(scan =>
                          scan.FromAssembliesOf(typeof(IModuleDiscover))
                              .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                              .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                              .AsImplementedInterfaces()
                              .WithScopedLifetime()
                              .AddClasses(
                                  classes => classes.Where(type =>
                                                               type.Name.EndsWith("QueryHandler", StringComparison.OrdinalIgnoreCase)), publicOnly: false)
                              .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                              .AsImplementedInterfaces()
                              .WithScopedLifetime()
                              .AddClasses(
                                  classes => classes.Where(type =>
                                                               type.Name.EndsWith("CommandHandler", StringComparison.OrdinalIgnoreCase)),
                                  publicOnly: false)
                              .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                              .AsImplementedInterfaces()
                              .WithScopedLifetime()
                              .AddClasses(
                                  classes => classes.Where(type =>
                                                               type.Name.EndsWith("NotificationHandler", StringComparison.OrdinalIgnoreCase)),
                                  publicOnly: false)
                              .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                              .AsImplementedInterfaces()
                              .WithScopedLifetime());
        return services;
    }
}