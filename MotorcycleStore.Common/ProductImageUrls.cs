namespace MotorcycleStore.Common;

public static class ProductImageUrls
{
    public const char Separator = ';';

    public static IReadOnlyList<string> Parse(string? imageUrls)
    {
        if (string.IsNullOrWhiteSpace(imageUrls))
            return Array.Empty<string>();

        return imageUrls
            .Split(Separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .ToList();
    }

    public static string Join(IEnumerable<string> urls)
    {
        return string.Join(Separator, urls.Where(u => !string.IsNullOrWhiteSpace(u)).Select(u => u.Trim()));
    }

    public static string Append(string? existing, string newUrl)
    {
        var list = Parse(existing).ToList();
        if (!list.Contains(newUrl, StringComparer.OrdinalIgnoreCase))
            list.Add(newUrl);
        return Join(list);
    }
}
