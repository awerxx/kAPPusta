namespace Avvr.Kappusta.Kappusta.Common.Model;

public abstract class Entity<TId> where TId : notnull
{
    protected Entity(TId id) => Id = id ?? throw new ArgumentNullException(nameof(id));
    public TId Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode() => Id.GetHashCode();
}