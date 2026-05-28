// Project: SaaSManagement, 22/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Entities;

public sealed class BusinessCustomer : Customer
{
    private readonly List<BusinessContact> _contacts = [];
    [MaxLength(60)] public string LegalName { get; private set; }
    [MaxLength(60)] public string FantasyName { get; private set; }
    [MaxLength(21)] public string RegistrationNumber { get; private set; }
    [MaxLength(40)] public string RegistrationBody { get; private set; }
    public IReadOnlyCollection<BusinessContact> Contacts => _contacts;


    public void AddContact(BusinessContact contact) => _contacts.Add(contact);

    public void RemoveContact(string contactId)
    {
        var contact = _contacts.FirstOrDefault(c => c.GetId() == contactId);
        if (contact != null) _contacts.Remove(contact);
    }

    public void UpdateContact(string contactId, string fullName, PhoneNumber phoneNumber, Email email, string positionName)
    {
        var ct = _contacts.FirstOrDefault(c => c.GetId().Equals(contactId, StringComparison.OrdinalIgnoreCase))
         ?? throw new ArgumentException(
                $"Contact with id {contactId} does not exist");
        ct.UpdateFullName(fullName);
        ct.UpdateEmail(email);
        ct.UpdatePhoneNumber(phoneNumber);
        ct.UpdatePositionName(positionName);
    }


    public override string GetFullName() => LegalName;
}