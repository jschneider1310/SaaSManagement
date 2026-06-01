// Project: SaaSManagement, 01/06/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.Shared.Common;

namespace SaaSManagement.Core.Shared.Abstractions.Interfaces;

/// <summary>
/// Interface that handles queries with a response type.
/// </summary>
/// <typeparam name="TQuery">TQuery</typeparam>
/// <typeparam name="TResponse">TResponse</typeparam>
public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}