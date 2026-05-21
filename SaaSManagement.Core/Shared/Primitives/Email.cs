// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SaaSManagement.Core.Shared.Abstractions;
using SaaSManagement.Core.Shared.Exceptions;
using SaaSManagement.Core.Shared.Utilities;

namespace SaaSManagement.Core.Shared.Primitives;
/// <summary>
/// Represents an email value object.
/// </summary>
public sealed class Email : ValueObject
{
    /// <summary>
    /// The email maximum length.
    /// </summary>
    private const int MaxLength = 256;

    /// <summary>
    /// Initializes a new instance of the <see cref="Email"/> class.
    /// </summary>
    /// <param name="value">The email value.</param>
    [JsonConstructor]
    internal Email(string value) => Value = value;

    /// <summary>
    /// Gets the email value.
    /// </summary>
    [DataType(DataType.EmailAddress)]
    [MaxLength(MaxLength)]
    public required string Value { get; init; }

    /// <summary>
    /// Static Implicit operator that receives an email and returns the email value as string.
    /// </summary>
    /// <param name="email">Email <see cref="Email"/> object</param>
    /// <returns>String</returns>
    public static implicit operator string(Email email) => email.Value;

    /// <summary>
    /// Static Implicit Operator that receives a string and returns a new <see cref="Email"/> object.
    /// </summary>
    /// <param name="email">Email <see cref="Email"/> object</param>
    /// <returns>Email <see cref="Email"/> object.</returns>
    public static implicit operator Email(string email) => Create(email);

    /// <summary>
    /// Creates a new <see cref="Email"/> instance based on the specified value.
    /// </summary>
    /// <param name="email">The email value.</param>
    /// <returns>The result of the email creation process containing the email or an error.</returns>
    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new EmailException("Email cannot be null or empty", nameof(email));
        if (email.Length > MaxLength)
            throw new EmailException("Email cannot be longer than 256 characters", nameof(email));
        if (!EmailVerificationUtility.IsValidEmail(email))
            throw new EmailException("Invalid Email format", nameof(email));

        return new Email(email)
               {
                   Value = email
               };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}