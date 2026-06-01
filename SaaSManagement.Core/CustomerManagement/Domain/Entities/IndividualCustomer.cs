// Project: SaaSManagement, 22/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.CustomerManagement.Domain.Constants;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Domain.Entities;

/// <summary>
/// This class represents an Individual Client into the system as an aggregate
/// that inherits from <see cref="Customer"/>
/// </summary>
public sealed class IndividualCustomer : Customer
{
    [MaxLength(30)] public string FirstName { get; private set; }
    [MaxLength(30)] public string LastName { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public CustomerType CustomerType { get; } = CustomerType.Individual;

    private IndividualCustomer(Email email, PhoneNumber phoneNumber,
        string? websiteAddress, string firstName, string lastName,
        DateOnly birthDate) : base(email, phoneNumber, websiteAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    /// <summary>
    /// Creates a neu IndividualCustomer object from parameters.
    /// </summary>
    /// <param name="email"><see cref="Email"/></param>
    /// <param name="phoneNumber"><see cref="PhoneNumber"/></param>
    /// <param name="websiteAddress">String</param>
    /// <param name="firstName">String with a maximum of 30 characters.</param>
    /// <param name="lastName">String with a maximum of 30 characters.</param>
    /// <param name="birthDate"><see cref="DateOnly"/> with the birthdate.</param>
    /// <returns>A new <see cref="IndividualCustomer"/> object.</returns>
    public static IndividualCustomer Create(Email email, PhoneNumber phoneNumber,
        string? websiteAddress, string firstName, string lastName, DateOnly birthDate)
    {
        return new IndividualCustomer(email,
            phoneNumber,
            websiteAddress,
            firstName,
            lastName,
            birthDate);
    }

    public override string GetFullName() => $"{FirstName} {LastName}";
}