// Project: SaaSManagement, 01/06/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Abstractions.Interfaces;
/// <summary>
/// Interface that handles ICommand objects.
/// </summary>
/// <typeparam name="TCommand">TCommand type</typeparam>
public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task Handle(TCommand command, CancellationToken cancellationToken);
}

/// <summary>
/// Interfaces that handles ICommand objects with a response type.
/// </summary>
/// <typeparam name="TCommand">TCommand</typeparam>
/// <typeparam name="TResponse">TResponse</typeparam>
public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}