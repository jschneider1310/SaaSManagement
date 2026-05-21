using System.Diagnostics.CodeAnalysis;

namespace SaaSManagement.Application.Abstractions.Interfaces;

/// <summary>
/// Interface for commands.
/// </summary>
public interface ICommand
{
}

/// <summary>
/// Interface for commands with a response type.
/// </summary>
/// <typeparam name="TResponse">The response type</typeparam>
public interface ICommand<TResponse>
{
}