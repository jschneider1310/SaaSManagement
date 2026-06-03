// Project: SaaSManagement, 28/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.CustomerManagement.Domain.Constants;
using SaaSManagement.Core.CustomerManagement.Domain.Primitives;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Primitives;
using SaaSManagement.Core.Shared.Utilities;

namespace SaaSManagement.Core.CustomerManagement.Domain.Entities;

/// <summary>
/// Represents a contact of the <see cref="BusinessCustomer"/>
/// </summary>
public sealed class BusinessContact : Entity<string>
{
    public string ContactId { get; private set ; } = Guid.NewGuid().ToString();

    [MaxLength(CustomerManagementConstants.MaximumFullNameLength)]
    public string FullName { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }

    [MaxLength(CustomerManagementConstants.MaximumShortStringFieldLength)]
    public string PositionName { get; private set; }

    public ClientId ClientId { get; private set; }

    private BusinessContact(string fullName, PhoneNumber phoneNumber, Email email,
        string positionName, ClientId clientId)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        PositionName = positionName;
        ClientId = clientId;
    }

    /// <summary>
    /// Creates a new BusinessContact
    /// </summary>
    /// <param name="fullName">String</param>
    /// <param name="phoneNumber"><see cref="PhoneNumber"/></param>
    /// <param name="email"><see cref="Email"/></param>
    /// <param name="positionName">String</param>
    /// <param name="clientId"><see cref="ClientId"/></param>
    /// <returns>A newly created <see cref="BusinessContact"/></returns>
    /// <exception cref="ArgumentException">If full name or position name are null, empty, or white spaces.</exception>
    public static BusinessContact Create(string fullName, PhoneNumber phoneNumber,
        Email email, string positionName, ClientId clientId)
    {
        if (!VerifyIf.IsNotEmptyOrNullString(fullName, positionName))
            throw new ArgumentException(
                $"Full name or position name is invalid: {fullName} - {positionName}");

        return new BusinessContact(fullName, phoneNumber, email, positionName, clientId);
    }

    /// <summary>
    /// Updates the fullname 
    /// </summary>
    /// <param name="fullName">String</param>
    /// <exception cref="ArgumentException">If null, empty, or white spaces.</exception>
    public void UpdateFullName(string fullName)
    {
        if (!VerifyIf.IsNotEmptyOrNullString(fullName))
            throw new ArgumentException($"Full name is invalid: {fullName}");

        FullName = fullName;
    }

    /// <summary>
    /// Updates the phone number.
    /// </summary>
    /// <param name="phoneNumber"><see cref="PhoneNumber"/></param>
    public void UpdatePhoneNumber(PhoneNumber phoneNumber) => PhoneNumber = phoneNumber;

    /// <summary>
    /// Updates the email.
    /// </summary>
    /// <param name="email"><see cref="Email"/></param>
    public void UpdateEmail(Email email) => Email = email;

    /// <summary>
    /// Updates the position name.
    /// </summary>
    /// <param name="positionName">String with a maximum of 40 characters.</param>
    /// <exception cref="ArgumentException">If null, empty, or white spaces.</exception>
    public void UpdatePositionName(string positionName)
    {
        if (!VerifyIf.IsNotEmptyOrNullString(positionName))
            throw new ArgumentException($"Position name is invalid: {positionName}");

        PositionName = positionName;
    }


    public override string GetId() => ContactId;
}