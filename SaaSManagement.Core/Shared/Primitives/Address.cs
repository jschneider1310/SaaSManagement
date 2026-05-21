// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Abstractions;
using SaaSManagement.Core.Shared.Abstractions.Classes;

namespace SaaSManagement.Core.Shared.Primitives;

public abstract class Address : ValueObject
{
    protected Address()
    {
    }

    /// <summary>
    /// Creates a new address with the given properties.
    /// </summary>
    /// <param name="numberOrBuildingName">String</param>
    /// <param name="addressLine1">String</param>
    /// <param name="addressLine2">String</param>
    /// <param name="postalCode">String</param>
    /// <param name="city">String</param>
    /// <param name="borough">String</param>
    /// <param name="country">String</param>
    protected Address(string numberOrBuildingName, string addressLine1, string addressLine2,
        string postalCode, string city, string borough, string country)
    {

        NumberOrBuildingName = numberOrBuildingName;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        PostalCode = postalCode;
        City = city;
        Borough = borough;
        Country = country;
    }
    
    [MaxLength(60)] public string NumberOrBuildingName { get; private set; } = string.Empty;

    [MaxLength(60)] public string AddressLine1 { get; private set; } = string.Empty;

    [MaxLength(60)] public string AddressLine2 { get; private set; } = string.Empty;

    [MaxLength(30)] public string PostalCode { get; private set; } = string.Empty;

    [MaxLength(60)] public string City { get; private set; } = string.Empty;

    [MaxLength(60)] public string Borough { get; private set; } = string.Empty;

    [MaxLength(60)] public string Country { get; private set; } = string.Empty;

    protected void UpdateNumberOrBuildingName(string numberOrBuildingName)
    {
        NumberOrBuildingName = numberOrBuildingName;
    }

    protected void UpdateAddressLine1(string addressLine1)
    {
        AddressLine1 = addressLine1;
    }

    protected void UpdateAddressLine2(string addressLine2)
    {
        AddressLine2 = addressLine2;
    }

    protected void UpdatePostalCode(string postalCode)
    {
        PostalCode = postalCode;
    }

    protected void UpdateCity(string city)
    {
        City = city;
    }

    protected void UpdateBorough(string borough)
    {
        Borough = borough;
    }

    protected void UpdateCountry(string country)
    {
        Country = country;
    }
}