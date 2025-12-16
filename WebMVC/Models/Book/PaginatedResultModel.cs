namespace WebMVC.Models.Book;

public sealed class PaginatedResultModel<T>
{
    public required IReadOnlyList<T> Items { get; init; }

    public required int PageIndex { get; init; }
    public required int PageSize { get; init; }
    public required int TotalCount { get; init; }

    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}