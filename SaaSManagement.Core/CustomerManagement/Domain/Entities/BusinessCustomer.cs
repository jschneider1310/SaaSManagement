// Project: SaaSManagement, 22/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.CustomerManagement.Domain.Constants;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Domain.Entities;
/// <summary>
/// This class represents a Business Client into the system as an aggregate that
/// inherits from <see cref="Customer"/>
/// </summary>
public sealed class BusinessCustomer : Customer
{
    private readonly List<BusinessContact> _contacts = [];

    [MaxLength(60)] public string LegalName { get; private set; }
    [MaxLength(60)] public string FantasyName { get; private set; }
    [MaxLength(21)] public string RegistrationNumber { get; private set; }
    [MaxLength(40)] public string RegistrationBody { get; private set; }
    public CustomerType  CustomerType { get; } = CustomerType.Business; 
    public IReadOnlyCollection<BusinessContact> Contacts => _contacts;

    private BusinessCustomer(Email email, PhoneNumber phoneNumber, string? websiteAddress,
        string legalName, string fantasyName, string registrationNumber,
        string registrationBody) : base(
        email,
        phoneNumber,
        websiteAddress)
    {
        LegalName = legalName ?? throw new ArgumentNullException(nameof(legalName));
        FantasyName = fantasyName ?? throw new ArgumentNullException(nameof(fantasyName));
        RegistrationNumber = registrationNumber
         ?? throw new ArgumentNullException(nameof(registrationNumber));

        RegistrationBody = registrationBody
         ?? throw new ArgumentNullException(nameof(registrationBody));
    }

    /// <summary>
    /// This method creates a new BusinessCustomer from the given parameters.
    /// </summary>
    /// <param name="email"><see cref="Email"/></param>
    /// <param name="phoneNumber"><see cref="PhoneNumber"/></param>
    /// <param name="websiteAddress">String</param>
    /// <param name="legalName">String</param>
    /// <param name="fantasyName">String</param>
    /// <param name="registrationNumber">String</param>
    /// <param name="registrationBody">String</param>
    /// <returns>A new <see cref="BusinessCustomer"/> object.</returns>
    public static BusinessCustomer Create(Email email, PhoneNumber phoneNumber,
        string? websiteAddress, string legalName, string fantasyName,
        string registrationNumber, string registrationBody)
    {
        return new BusinessCustomer(email,
            phoneNumber,
            websiteAddress,
            legalName,
            fantasyName,
            registrationNumber,
            registrationBody);
    }

    /// <summary>
    /// Adds a new <see cref="BusinessContact"/> to the aggregate.
    /// </summary>
    /// <param name="contact"><see cref="BusinessContact"/></param>
    public void AddContact(BusinessContact contact) => _contacts.Add(contact);

    /// <summary>
    /// Removes a <see cref="BusinessContact"/>
    /// </summary>
    /// <param name="contactId">String</param>
    public void RemoveContact(string contactId)
    {
        var contact = _contacts.FirstOrDefault(c => c.GetId() == contactId);
        if (contact != null) _contacts.Remove(contact);
    }

    /// <summary>
    /// Updates a existing <see cref="BusinessContact"/> with the provided information.
    /// </summary>
    /// <param name="contactId">String</param>
    /// <param name="fullName">String</param>
    /// <param name="phoneNumber"><see cref="PhoneNumber"/></param>
    /// <param name="email"><see cref="Email"/></param>
    /// <param name="positionName">String</param>
    /// <exception cref="ArgumentException">If no <see cref="BusinessContact"/> found or invalid/null parameters.</exception>
    public void UpdateContact(string contactId, string fullName, PhoneNumber phoneNumber,
        Email email, string positionName)
    {
        var ct
            = _contacts.FirstOrDefault(c => c.GetId()
                                           .Equals(contactId,
                                               StringComparison.OrdinalIgnoreCase))
         ?? throw new ArgumentException($"Contact with id {contactId} does not exist");

        ct.UpdateFullName(fullName);
        ct.UpdateEmail(email);
        ct.UpdatePhoneNumber(phoneNumber);
        ct.UpdatePositionName(positionName);
    }


    public override string GetFullName() => LegalName;
}