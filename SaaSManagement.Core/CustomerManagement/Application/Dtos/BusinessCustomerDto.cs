// Project: SaaSManagement, 25/06/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.CustomerManagement.Domain.Constants;
using SaaSManagement.Core.CustomerManagement.Domain.Entities;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Application.Dtos;

public record BusinessCustomerDto
{
    public string? Id { get; init; } 
    public List<Address>? Addresses { get; init; }
    public List<Note>? Notes { get; init; }
    public required Email Email { get; init; }
    public required PhoneNumber PhoneNumber { get; init; }
    [MaxLength(CustomerManagementConstants.MaximumWebsiteLength)] public string? WebsiteAddress { get; init; }
    
    [MaxLength(CustomerManagementConstants.MaximumBusinessLegalOrFantasyNameLength)]
    public required string LegalName { get; init; }

    [MaxLength(CustomerManagementConstants.MaximumBusinessLegalOrFantasyNameLength)]
    public required string FantasyName { get; init; }

    [MaxLength(CustomerManagementConstants.MaximumRegistrationNumberLength)]
    public required string RegistrationNumber { get; init; }

    [MaxLength(CustomerManagementConstants.MaximumRegistrationBodyNameLength)]
    public required string RegistrationBody { get; init; }

    public CustomerType CustomerType { get; } = CustomerType.Business;
    public List<BusinessContact> Contacts { get; init; } = [];

    public static implicit operator BusinessCustomerDto(BusinessCustomer customer)
    {
        return new BusinessCustomerDto
               {
                   Id = customer.Id,
                   Addresses = [.. customer.Addresses],
                   Notes = [.. customer.Notes],
                   LegalName = customer.LegalName,
                   FantasyName = customer.FantasyName,
                   RegistrationNumber = customer.RegistrationNumber,
                   RegistrationBody = customer.RegistrationBody,
                   Contacts = [.. customer.Contacts],
                   Email = customer.Email,
                   PhoneNumber = customer.PhoneNumber,
                   WebsiteAddress = customer.WebsiteAddress,
               };
    }

    public static implicit operator BusinessCustomer(BusinessCustomerDto dto)
    {
        if (dto.Id is null)
        {
            var customer = BusinessCustomer.Create(dto.Email, dto.PhoneNumber, dto.WebsiteAddress,
                dto.LegalName, dto.FantasyName, dto.RegistrationNumber, dto.RegistrationBody);

            if (dto.Addresses is not null && dto.Addresses.Count > 0) customer.AddAddress(dto.Addresses);
            if(dto.Contacts.Count > 0) customer.AddContacts(dto.Contacts);
            if(dto.Notes is not null && dto.Notes.Count > 0) customer.AddNote(dto.Notes);
            
            return customer;
        }
        var existingCustomer = BusinessCustomer.Create(dto.Id, dto.Email, dto.PhoneNumber, dto.WebsiteAddress,
            dto.LegalName, dto.FantasyName, dto.RegistrationNumber, dto.RegistrationBody);

        if (dto.Addresses is not null && dto.Addresses.Count > 0) existingCustomer.AddAddress(dto.Addresses);
        if(dto.Contacts.Count > 0) existingCustomer.AddContacts(dto.Contacts);
        if(dto.Notes is not null && dto.Notes.Count > 0) existingCustomer.AddNote(dto.Notes);
            
        return existingCustomer;
    }
}