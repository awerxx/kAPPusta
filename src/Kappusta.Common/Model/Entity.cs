namespace Avvr.Kappusta.Kappusta.Common.Model;

public abstract class Entity<TId> : IEqualityComparer<Entity<TId>>, IEquatable<Entity<TId>> where TId : notnull
{
    public TId Id { get; }

    protected Entity(TId id) => Id = id;

    public bool Equals(Entity<TId>? other) => Equals((object?)other);

    public override bool Equals(object? obj) => obj is Entity<TId> entity && Id.Equals(entity.Id);

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity<TId>? a, Entity<TId>? b) => Equals(a, b);

    public static bool operator !=(Entity<TId>? a, Entity<TId>? b) => !Equals(a, b);

    public bool Equals(Entity<TId>? x, Entity<TId>? y)
    {
        if (ReferenceEquals(x, y))
            return true;
        if (x is null)
            return false;
        if (y is null)
            return false;
        if (x.GetType() != y.GetType())
            return false;
        return EqualityComparer<TId>.Default.Equals(x.Id, y.Id);
    }

    public int GetHashCode(Entity<TId> obj) => EqualityComparer<TId>.Default.GetHashCode(obj.Id);
}