﻿namespace Avvr.Kappusta.Kappusta.Common.Model;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
        => GetEqualityComponents().Select(obj => obj?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
}