namespace System.Linq;

public static class MyLinqExtensions
{
    public static IEnumerable<T> ProcessSequence<T>(this IEnumerable<T> sequence)
    {
        return sequence;
    }

    public static IQueryable<T> ProcessSequence<T>(this IQueryable<T> sequence)
    {
        return sequence;
    }

    public static int? Median(this IEnumerable<int?> sequnece)
    {
        var ordered = sequnece.OrderBy(item => item);
        int middlePosition = ordered.Count() / 2;
        return ordered.ElementAt(middlePosition);
    }

    public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
    {
        return sequence.Select(selector).Median();
    }

    public static decimal? Median(this IEnumerable<decimal?> sequnece)
    {
        var ordered = sequnece.OrderBy(item => item);
        int middlePosition = ordered.Count() / 2;
        return ordered.ElementAt(middlePosition);
    }

    public static decimal? Median<T>(this IEnumerable<T> sequnece, Func<T, decimal?> selector)
    {
        return sequnece.Select(selector).Median();
    }

    public static int? Mode(this IEnumerable<int?> sequence)
    {
        var grouped = sequence.GroupBy(item => item);
        var orderedGroup = grouped.OrderByDescending(group => group.Count());
        return orderedGroup.FirstOrDefault()?.Key;
    }

    public static int? Mode<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
    {
        return sequence.Select(selector)?.Mode();
    }

    public static decimal? Mode(this IEnumerable<decimal?> sequence)
    {
        var grouped = sequence.GroupBy(item => item);
        var orderedGroup = grouped.OrderByDescending(group => group.Count());
        return orderedGroup.FirstOrDefault()?.Key;
    }

    public static decimal? Mode<T>(this IEnumerable<T> sequence, Func<T, decimal?> selector)
    {
        return sequence.Select(selector).Mode();
    }
}