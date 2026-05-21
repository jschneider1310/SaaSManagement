// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.Net.Mail;

namespace SaaSManagement.Core.Shared.Utilities;

public static class VerifyIf
{
    /// <summary>
    /// Verifies if a given string representing an e-mail address is valid.
    /// </summary>
    /// <param name="email">String</param>
    /// <returns>True if the email is valid, and false otherwise.</returns>
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        if (email.Contains(' ')) return false;

        if (!MailAddress.TryCreate(email, out var mailAddress)) return false;

        var hostParts = mailAddress.Host.Split('.');

        // No dot.
        if (hostParts.Length < 2) return false;
        // Double dot.
        if (hostParts.Any(part => part == string.Empty)) return false;
        // TLD only one character.
        if (hostParts[^1].Length < 2) return false;
        //Space in user part.
        if (mailAddress.User.Contains(' ')) return false;
        //Double dot or dot at the end of user part.
        if (mailAddress.User.Split('.').Any(p => p == string.Empty)) return false;

        return true;
    }

    /// <summary>
    /// Verifies if a given integer is greater or equal zero.
    /// </summary>
    /// <param name="value">Integer</param>
    /// <returns>True if the integer is zero or positive, and false if it is negative.</returns>
    public static bool IsPositiveInteger(int value) { return value >= 0; }

    /// <summary>
    /// Verifies if a given double is greater or equal to zero.
    /// </summary>
    /// <param name="value">Double</param>
    /// <returns>True if it is greater or equal zero, and false otherwise.</returns>
    public static bool NegativeDouble(double value) { return value >= 0.0; }

    /// <summary>
    /// Verifies if a given string value is NOT null, empty, or white spaces.
    /// </summary>
    /// <param name="value">String</param>
    /// <returns>True if it is not null or empty or white spaces, and false otherwise.</returns>
    public static bool IsNotEmptyOrNullString(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Verifies if a given string value is NOT null, empty, or white spaces.
    /// </summary>
    /// <param name="value1">String</param>
    /// <param name="value2">String</param>
    /// <returns>True if it is not null or empty or white spaces, and false otherwise.</returns>
    public static bool IsNotEmptyOrNullString(string value1, string value2)
    {
        return !string.IsNullOrWhiteSpace(value1) || !string.IsNullOrWhiteSpace(value2);
    }

    /// <summary>
    /// Verifies if a given string value is NOT null, empty, or white spaces.
    /// </summary>
    /// <param name="value1">String</param>
    /// <param name="value2">String</param>
    /// <param name="value3">String</param>
    /// <returns>True if it is not null or empty or white spaces, and false otherwise.</returns>
    public static bool IsNotEmptyOrNullString(string value1, string value2, string value3)
    {
        return !string.IsNullOrWhiteSpace(value1)
         || !string.IsNullOrWhiteSpace(value2)
         || !string.IsNullOrWhiteSpace(value3);
    }

    /// <summary>
    /// Verifies if a given string value is NOT null, empty, or white spaces.
    /// </summary>
    /// <param name="value1">String</param>
    /// <param name="value2">String</param>
    /// <param name="value3">String</param>
    /// <param name="value4">String</param>
    /// <returns>True if it is not null or empty or white spaces, and false otherwise.</returns>
    public static bool
        IsNotEmptyOrNullString(string value1, string value2, string value3, string value4)
    {
        return !string.IsNullOrWhiteSpace(value1)
         || !string.IsNullOrWhiteSpace(value2)
         || !string.IsNullOrWhiteSpace(value3)
         || !string.IsNullOrWhiteSpace(value4);
    }
}