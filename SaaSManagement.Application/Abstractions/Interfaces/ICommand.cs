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
#pragma warning disable S2326
public interface ICommand<TResponse>
#pragma warning restore S2326
{
}