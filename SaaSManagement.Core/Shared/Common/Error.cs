namespace SaaSManagement.Core.Shared.Common;

/// <summary>
/// Represents a response error for an <see cref="Result"/>
/// </summary>
public sealed class Error : IEquatable<Error>
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");

    /// <summary>
    /// Constructor that returns an Error object with all information needed.
    /// </summary>
    /// <param name="message">String with the description message</param>
    /// <param name="instance">String with the name of the entity/method</param>
    /// <param name="statusCode">Integer with the internal status code.</param>
    /// <param name="code">String</param>
    /// <param name="title">String</param>
    /// <param name="type">String with the problem type.</param>
    public Error(string message, string instance, int statusCode, string code, string title, string type)
    {
        Code = code;
        Message = message;
        Instance = instance;
        StatusCode = statusCode;
        Title = title;
        Type = type;
    }

    /// <summary>
    /// Constructor that returns an Error object with the code and message.
    /// </summary>
    /// <param name="code">String</param>
    /// <param name="message">String</param>
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }
    public string Instance { get; } = string.Empty;
    public int StatusCode { get; }
    public string Title { get; } = string.Empty;
    public string Type { get; } = string.Empty;

    public bool Equals(Error? other)
    {
        if (other is null)
        {
            return false;
        }

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj) => obj is Error error && Equals(error);


    /// <summary>
    /// Implicit conversion from Error to string
    /// </summary>
    /// <param name="error">Error object</param>
    /// <returns>String</returns>
    public static implicit operator string(Error error) => error.Code;

    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Error? a, Error? b) => !(a == b);


    public override int GetHashCode() => HashCode.Combine(Code, Message);

    public override string ToString() => Code;
}