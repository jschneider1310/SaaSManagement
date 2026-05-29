// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Abstractions;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Exceptions;
using SaaSManagement.Core.Shared.Utilities;

namespace SaaSManagement.Core.Shared.Primitives;
/// <summary>
/// This class represents a postal address into the system.
/// <remarks>
/// As an address is considered important information for legal purposes, only the Borough is
/// allowed to be empty or nullable. If any other fields are null, empty, or white spaces
/// it throws an <see cref="AddressArgumentException"/> 
/// </remarks>
/// </summary>
public sealed class Address : ValueObject
{
    private Address()
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
    public Address(string numberOrBuildingName, string addressLine1, string addressLine2,
        string postalCode, string city, string borough, string country)
    {
        // Verifying for empty strings
        var add1 = VerifyIf.IsNotEmptyOrNullString(numberOrBuildingName, addressLine1, addressLine2,  postalCode);
        var add2 = VerifyIf.IsNotEmptyOrNullString(city, city, country);
        if (!add1 || !add2)
            throw new AddressArgumentException(
                $"The address contains null arguments where required. Verify the arguments and try again.");
        
        AddressId = new  AddressId();
        NumberOrBuildingName = numberOrBuildingName;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        PostalCode = postalCode;
        City = city;
        Borough = borough;
        Country = country;
    }
    public AddressId AddressId { get; private set; } = null!;
    [MaxLength(60)] public string NumberOrBuildingName { get; private set; } = string.Empty;
    [MaxLength(60)] public string AddressLine1 { get; private set; } = string.Empty;
    [MaxLength(60)] public string AddressLine2 { get; private set; } = string.Empty;
    [MaxLength(15)] public string PostalCode { get; private set; } = string.Empty;
    [MaxLength(40)] public string City { get; private set; } = string.Empty;
    [MaxLength(40)] public string? Borough { get; private set; } = string.Empty;
    [MaxLength(60)] public string Country { get; private set; } = string.Empty;
    /// <summary>
    /// Updates the corresponding value. If the value is null or empty (or white spaces)
    /// it throws an <see cref="AddressArgumentException"/>
    /// </summary>
    /// <param name="numberOrBuildingName">String with the place number or building name.</param>
    public void UpdateNumberOrBuildingName(string numberOrBuildingName)
    {
        VerifyStringForNullOrEmpty(numberOrBuildingName);
        NumberOrBuildingName = numberOrBuildingName;
    }
    /// <summary>
    /// Updates the Address Line 1
    /// </summary>
    /// <param name="addressLine1">String with maximum of 60 characters.</param>
    public void UpdateAddressLine1(string addressLine1)
    {
        VerifyStringForNullOrEmpty(addressLine1);
        AddressLine1 = addressLine1;
    }
    /// <summary>
    /// Updates the address line 2
    /// </summary>
    /// <param name="addressLine2">String with maximum of 60 characters.</param>
    public void UpdateAddressLine2(string addressLine2)
    {
        VerifyStringForNullOrEmpty(addressLine2);
        AddressLine2 = addressLine2;
    }
    /// <summary>
    /// Updates the post code.
    /// </summary>
    /// <param name="postalCode">String with maximum of 15 characters.</param>
    public void UpdatePostalCode(string postalCode)
    {
        VerifyStringForNullOrEmpty(postalCode);
        PostalCode = postalCode;
    }
    /// <summary>
    /// Updates the city.
    /// </summary>
    /// <param name="city">String with maximum of 40 characters.</param>
    public void UpdateCity(string city)
    {
        VerifyStringForNullOrEmpty(city);
        City = city;
    }
    /// <summary>
    /// Updates the borough if any. If no value provided it is set to null.
    /// </summary>
    /// <param name="borough">String with maximum of 40 characters.</param>
    public void UpdateBorough(string? borough)
    {
        Borough = string.IsNullOrWhiteSpace(borough) ? null : borough;
    }
    /// <summary>
    /// Updates the country of an address.
    /// </summary>
    /// <param name="country">String with maximum of 60 characters.</param>
    public void UpdateCountry(string country)
    {
        VerifyStringForNullOrEmpty(country);
        Country = country;
    }
    /// <summary>
    /// Verifies if it is null, empty, or white spaces.
    /// </summary>
    /// <param name="param">String</param>
    /// <exception cref="AddressArgumentException">If the given parameter is null, empty, or white spaces.</exception>
    private static void VerifyStringForNullOrEmpty(string param)
    {
        if(!VerifyIf.IsNotEmptyOrNullString(param))
            throw new AddressArgumentException($"The parameter {param} cannot be null or empty.");
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return AddressId;
        yield return NumberOrBuildingName;
        yield return AddressLine1;
        yield return AddressLine2;
        yield return PostalCode;
        yield return City;
        yield return Country;
    }
}