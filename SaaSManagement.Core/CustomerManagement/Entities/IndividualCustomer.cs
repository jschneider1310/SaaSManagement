// Project: SaaSManagement, 22/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;

namespace SaaSManagement.Core.CustomerManagement.Entities;

public sealed class IndividualCustomer : Customer
{
    [MaxLength(30)] public string FirstName { get; private set; }
    [MaxLength(30)] public string LastName { get; private set; }
    public DateOnly BirthDate { get; private set; }


    public override string GetFullName() =>  $"{FirstName} {LastName}";
}