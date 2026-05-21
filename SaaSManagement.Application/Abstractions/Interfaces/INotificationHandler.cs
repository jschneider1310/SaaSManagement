// Project: LegalOfficeCRM, 27/06/2025
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Application.Abstractions.Interfaces;

/// <summary>
/// Interface for handling notifications.
/// </summary>
/// <typeparam name="T">Generic Type</typeparam>
public interface INotificationHandler<in T> where T : INotification
{
    Task Handle(T notification, CancellationToken ct = default);
}