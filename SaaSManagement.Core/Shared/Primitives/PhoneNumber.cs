// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;
using SaaSManagement.Core.Shared.Abstractions;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Exceptions;

namespace SaaSManagement.Core.Shared.Primitives;

public sealed class PhoneNumber : ValueObject
{
    private const string DefaultCountryCode = "+44"; // Default to UK country code
    private const int DefaultAreaCode = 0; // Default to UK area code
    private const int MinimumCountryCodeLength = 2; // The smaller is +1 which is lenght 2
    private const int MaximumCountryCodeLength = 6; // The bigger is 00853 which is 5
    private const int MinimumAreaCodeLength = 1;
    private const int MaximumAreaCodeLength = 3;
    private const int MinimumNumberLength = 3;
    private const int MaximumNumberLength = 15;
    private const int MaximumPhoneNumberLength = 26;

    // Constructors

    private PhoneNumber()
    {
    }

    [JsonConstructor]
    public PhoneNumber(string countryCode, int areaCode, string number)
    {
        if (string.IsNullOrWhiteSpace(countryCode) || countryCode.Length < MinimumCountryCodeLength || countryCode.Length > MaximumCountryCodeLength)
            throw new PhoneNumberException("Invalid or empty country code.");

        if (areaCode is < MinimumAreaCodeLength or > MaximumAreaCodeLength)
            throw new PhoneNumberException("Area code number must be between 1 and 3 digits length.");

        if (number.Length is < MinimumNumberLength or >MaximumNumberLength)
            throw new PhoneNumberException("Phone number must be between 3 and 15 numbers long.");

        CountryCode = countryCode;
        AreaCode = areaCode;
        Number = number;
        Value = $"{CountryCode} {AreaCode} {Number}";
    }

    public PhoneNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new PhoneNumberException("Phone number cannot be empty.");

        if (HasPlusSignAndSpace(number))
        {
            var parts = number.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CountryCode = parts[0];
            AreaCode = int.Parse(string.Create(CultureInfo.InvariantCulture, $"{parts[1]}"));
            Number = parts[2];
            Value = number;
        }
        else if (HasPlusSignAndNoSpace(number))
        {
            Value = number;
        }
        else
        {
            CountryCode = DefaultCountryCode;
            AreaCode = DefaultAreaCode;
            Number = number;
            Value = $"{CountryCode} {AreaCode} {Number}";
        }
    }

    [MaxLength(MaximumCountryCodeLength)] public string CountryCode { get; set; }
        = string.Empty; // +1, +44, +356, etc..
    [MaxLength(MaximumAreaCodeLength)] public int AreaCode { get; private set; } // 0, 51, 852, etc..

    [DataType(DataType.PhoneNumber)]
    [MaxLength(MaximumNumberLength)]
    public string Number { get; set; } = string.Empty;
    [MaxLength(MaximumPhoneNumberLength)] public string Value { get; private set; }

    private static bool HasPlusSignAndSpace(string number)
    {
        return (number.StartsWith('+') || number.StartsWith("00", StringComparison.OrdinalIgnoreCase)) &&
               number.Contains(' ', StringComparison.OrdinalIgnoreCase);
    }

    private static bool HasPlusSignAndNoSpace(string number)
    {
        return (number.StartsWith('+') || number.StartsWith("00", StringComparison.OrdinalIgnoreCase)) &&
               !number.Contains(' ', StringComparison.OrdinalIgnoreCase);
    }

    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;

    public static implicit operator PhoneNumber(string phoneNumber)
    {
        return new PhoneNumber(phoneNumber);
    }


    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}