// Project: SaaSManagement, 01/06/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Abstractions.Interfaces;

/// <summary>
/// Interface for commands with no response type.
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
#pragma warning disable S2326
{
}