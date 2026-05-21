// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.Windows.Input;
using SaaSManagement.Application.Abstractions.Interfaces;
using Scrutor;
using ICommand = SaaSManagement.Application.Abstractions.Interfaces.ICommand;

namespace SaaSManagement.Web.Extensions;
internal static class HandlersRegistrationExtension
{
    public static IServiceCollection RegisterApplicationHandlers(this IServiceCollection services)
    {
        services.Scan(scan =>
                          scan.FromAssembliesOf(typeof(ICommand))
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