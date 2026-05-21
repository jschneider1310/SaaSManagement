// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Abstractions.Classes;

/// <summary>
/// Abstract class that represents the value object.
/// </summary>
#pragma warning disable S4035
public abstract class ValueObject : IEquatable<ValueObject>
#pragma warning restore S4035
{
    /// <inheritdoc />
    public bool Equals(ValueObject? other)
        => !(other is null) && GetAtomicValues().SequenceEqual(other.GetAtomicValues());


    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj == null) { return false; }

        if (GetType() != obj.GetType()) { return false; }

        if (!(obj is ValueObject valueObject)) { return false; }

        return GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
    }

    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null) { return true; }

        if (a is null || b is null) { return false; }

        return a.Equals(b);
    }


    public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);


    /// <inheritdoc />
    public override int GetHashCode()
    {
        HashCode hashCode = default;

        foreach (object obj in GetAtomicValues()) { hashCode.Add(obj); }

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Gets the atomic values of the value object.
    /// </summary>
    /// <returns>The collection of objects representing the value object values.</returns>
    protected abstract IEnumerable<object> GetAtomicValues();
}