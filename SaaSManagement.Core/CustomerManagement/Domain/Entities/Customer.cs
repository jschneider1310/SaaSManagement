// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.CustomerManagement.Domain.Constants;
using SaaSManagement.Core.CustomerManagement.Domain.Primitives;
using SaaSManagement.Core.ServicesManagement.Domain.Entities;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Domain.Entities;

/// <summary>
/// Represents a Customer into the system. It is the aggregate root for different
/// types of customers (<see cref="IndividualCustomer"/> and <see cref="BusinessCustomer"/>).
/// Here we placed all common fields for a customer, leaving the specific implementations
/// of each type on its own responsibility.
/// </summary>
public abstract class Customer : AggregateRoot<ClientId>
{
    private readonly List<Address> _addresses = [];
    private readonly List<Note> _notes = [];
    /// <summary>
    /// The Id field uses a <see cref="ClientId"/> composed by a prefix C- followed by
    /// a <see cref="Ulid"/>, and is the same for both <see cref="IndividualCustomer"/>
    /// and <see cref="BusinessCustomer"/>
    /// </summary>
    public new ClientId Id { get; private set; } = new ClientId($"C-{Ulid.NewUlid()}");
    public IReadOnlyCollection<Address> Addresses => _addresses;
    public IReadOnlyCollection<Note> Notes => _notes;
    public Email Email { get; private set; } = null!;
    public PhoneNumber PhoneNumber { get; private set; } = null!;
    [MaxLength(CustomerManagementConstants.MaximumWebsiteLength)] public string? WebsiteAddress { get; private set; } = string.Empty;


    protected Customer(Email email, PhoneNumber phoneNumber, string? websiteAddress)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        WebsiteAddress = websiteAddress ?? string.Empty;
    }

    protected Customer() { }

    /// <summary>
    /// Gets the client's full name (first and last name) if an individual, or
    /// the company's legal name if a business.
    /// </summary>
    /// <returns>String with the full name.</returns>
    public abstract string GetFullName();


    /// <summary>
    /// Adds an <see cref="Address"/> to the aggregate root.
    /// </summary>
    /// <param name="address"><see cref="Address"/> object</param>
    public void AddAddress(Address address) => _addresses.Add(address);

    /// <summary>
    /// Removes an <see cref="Address"/> from the aggregate.
    /// </summary>
    /// <param name="address"><see cref="Address"/> object.</param>
    public void RemoveAddress(Address address) => _addresses.Remove(address);

    /// <summary>
    /// Updates an <see cref="Address"/> on the aggregate. If the address is not found,
    /// the given address is added, and updated otherwise.
    /// </summary>
    /// <param name="address"><see cref="Address"/> object.</param>
    public void UpdateAddress(Address address)
    {
        var addr = _addresses.Any(p => p.Equals(address));
        if (addr)
        {
            var oldAddress = _addresses.FirstOrDefault(p => p.Equals(address));
            oldAddress!.UpdateNumberOrBuildingName(address
                .NumberOrBuildingName); // Not null because it is a required field of Address object.

            oldAddress.UpdateAddressLine1(address.AddressLine1);
            oldAddress.UpdateAddressLine2(address.AddressLine2);
            oldAddress.UpdatePostalCode(address.PostalCode);
            oldAddress.UpdateCity(address.City);
            oldAddress.UpdateCountry(address.Country);
            oldAddress.UpdateBorough(address.Borough);
        }
        else { _addresses.Add(address); }
    }

    public void AddNote(Note note) => _notes.Add(note);
    public void RemoveNote(Note note) => _notes.Remove(note);

    public void UpdateNote(Note note)
    {
        var oldNote = _notes.FirstOrDefault(p => p.Equals(note));
        if (oldNote is not null)
        {
            oldNote.UpdateNote(note.Title, note.Content, note.NoteType);
        }
        else { _notes.Add(note); }
    }

    public void UpdateEmail(Email email) => Email = email;

    public void UpdateWebsiteAddress(string websiteAddress)
    {
        if (string.IsNullOrWhiteSpace(websiteAddress))
            throw new ArgumentNullException(nameof(websiteAddress));

        WebsiteAddress = websiteAddress;
    }

    public override string GetId() => Id;
}