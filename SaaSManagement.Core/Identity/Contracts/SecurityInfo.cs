// Project: LegalOfficeCRM
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Identity.Contracts;

/// <summary>
/// Represents security information captured from the client during authentication.
/// Used for anomaly detection and security auditing.
/// </summary>
public sealed record SecurityInfo
{
    /// <summary>
    /// The user agent string from the browser.
    /// </summary>
    public string? UserAgent { get; init; }

    /// <summary>
    /// The IP address of the client.
    /// </summary>
    public string? IpAddress { get; init; }

    /// <summary>
    /// The screen resolution of the client device.
    /// </summary>
    public string? ScreenResolution { get; init; }

    /// <summary>
    /// The timezone of the client.
    /// </summary>
    public string? Timezone { get; init; }

    /// <summary>
    /// The preferred language of the client.
    /// </summary>
    public string? Language { get; init; }

    /// <summary>
    /// The platform/OS of the client.
    /// </summary>
    public string? Platform { get; init; }

    /// <summary>
    /// Whether the device supports touch input.
    /// </summary>
    public bool? TouchSupport { get; init; }

    /// <summary>
    /// Whether cookies are enabled in the browser.
    /// </summary>
    public bool? CookiesEnabled { get; init; }

    /// <summary>
    /// A unique fingerprint generated from device characteristics.
    /// </summary>
    public string? Fingerprint { get; init; }

    /// <summary>
    /// The latitude from geolocation (if available).
    /// </summary>
    public double? Latitude { get; init; }

    /// <summary>
    /// The longitude from geolocation (if available).
    /// </summary>
    public double? Longitude { get; init; }

    /// <summary>
    /// The timestamp when this security info was captured.
    /// </summary>
    public DateTime CapturedAt { get; init; } = DateTime.UtcNow;
}

/// <summary>
/// Response containing JWT tokens after successful authentication.
/// </summary>
public sealed record TokenResponse
{
    /// <summary>
    /// The JWT access token for API authorization.
    /// </summary>
    public required string AccessToken { get; init; }

    /// <summary>
    /// The refresh token for obtaining new access tokens.
    /// </summary>
    public required string RefreshToken { get; init; }

    /// <summary>
    /// The expiration time of the access token.
    /// </summary>
    public required DateTime AccessTokenExpiry { get; init; }

    /// <summary>
    /// The expiration time of the refresh token.
    /// </summary>
    public required DateTime RefreshTokenExpiry { get; init; }

    /// <summary>
    /// The token type (always "Bearer").
    /// </summary>
    public string TokenType { get; init; } = "Bearer";
}