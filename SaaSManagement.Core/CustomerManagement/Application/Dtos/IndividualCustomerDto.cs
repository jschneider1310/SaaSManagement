// Project: SaaSManagement, 25/06/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.CustomerManagement.Domain.Constants;
using SaaSManagement.Core.CustomerManagement.Domain.Entities;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Application.Dtos;

public record IndividualCustomerDto
{
    public string? Id { get; init; } 
    public List<Address>? Addresses { get; init; }
    public List<Note>? Notes { get; init; }
    public required Email Email { get; init; }
    public required PhoneNumber PhoneNumber { get; init; }

    [MaxLength(CustomerManagementConstants.MaximumWebsiteLength)]
    public string? WebsiteAddress { get; private set; } = string.Empty;

    [MaxLength(CustomerManagementConstants.MaximumNameLength)]
    public required string FirstName { get; init; }

    [MaxLength(CustomerManagementConstants.MaximumNameLength)]
    public required string LastName { get; init; }

    public DateOnly BirthDate { get; init; }
    public CustomerType CustomerType { get; } = CustomerType.Individual;

    public static implicit operator IndividualCustomer(IndividualCustomerDto individual)
    {
        if (individual.Id is null)
        {
            return IndividualCustomer.Create(individual.Email,
                        individual.PhoneNumber,
                        individual.WebsiteAddress,
                        individual.FirstName,
                        individual.LastName,
                        individual.BirthDate);
                   
        }
        
        return IndividualCustomer.Create(individual.Id, individual.Email, individual.PhoneNumber,
            individual.WebsiteAddress, individual.FirstName,  individual.LastName,  individual.BirthDate);
    }

    public static implicit operator IndividualCustomerDto(IndividualCustomer individual)
    {
        return new IndividualCustomerDto
               {
                   Id = individual.Id,
                   Email = individual.Email,
                   PhoneNumber = individual.PhoneNumber,
                   FirstName = individual.FirstName,
                   LastName = individual.LastName,
                   BirthDate = individual.BirthDate,
                   Addresses = individual.Addresses.ToList(),
                   Notes = individual.Notes.ToList(),
               };
    }
    
}