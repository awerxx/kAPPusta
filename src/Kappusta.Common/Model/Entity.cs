namespace Avvr.Kappusta.Kappusta.Common.Model;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
{
    protected Entity(TId id) => Id = id;
    public TId Id { get; protected set; }

    public bool Equals(Entity<TId>? other) => Equals((object?)other);

    public override bool Equals(object? obj) => obj is Entity<TId> entity && Id.Equals(entity.Id);

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity<TId>? a, Entity<TId>? b) => Equals(a, b);

    public static bool operator !=(Entity<TId>? a, Entity<TId>? b) => !Equals(a, b);
}