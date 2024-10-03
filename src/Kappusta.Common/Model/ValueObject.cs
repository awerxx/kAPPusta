namespace Avvr.Kappusta.Kappusta.Common.Model;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject? a, ValueObject? b) => Equals(a, b);

    public static bool operator !=(ValueObject? a, ValueObject? b) => !Equals(a, b);

    public override int GetHashCode()
        => GetEqualityComponents().Select(obj => obj?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
}