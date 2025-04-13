namespace Avvr.Kappusta.Kappusta.Common.Extensions;

public static class EnumerableExtensions
{
    public static IReadOnlyCollection<T> ReadOnly<T>(this IEnumerable<T> enumerable)
        => enumerable.ToList().AsReadOnly();
}