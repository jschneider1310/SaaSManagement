// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.Net.Mail;

namespace SaaSManagement.Core.Shared.Utilities;

/// <summary>
/// Utility static class that verifies if an email address is correctly formed. It also
/// has a timeSpan control to avoid denial-of-service attacks
/// </summary>
public static class EmailVerificationUtility
{
    /// <summary>
    /// Verifies the email address formation.
    /// </summary>
    /// <param name="email">String with the email address</param>
    /// <returns>True if the email is valid, and false otherwise.</returns>
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        if(email.Contains(' '))
            return false;

        if(!MailAddress.TryCreate(email, out var mailAddress))
            return false;
        
        var hostParts = mailAddress.Host.Split('.');
        
        // No dot.
        if (hostParts.Length < 2)
            return false;
        // Double dot.
        if (hostParts.Any(part => part == string.Empty))
            return false;
        // TLD only one character.
        if(hostParts[^1].Length < 2)
            return false;
        //Space in user part.
        if(mailAddress.User.Contains(' '))
            return false;
        //Double dot or dot at the end of user part.
        if(mailAddress.User.Split('.').Any(p => p == string.Empty))
            return false;
        
        return true;
    }
}