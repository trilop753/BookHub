using BL.DTOs.BookDTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;

namespace WebMVC.Controllers;

public class SearchController : Controller
{
    private readonly IBookService _bookService;
    private readonly IAppCache _cache;

    public SearchController(IBookService bookService, IAppCache cache)
    {
        _bookService = bookService;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> Suggestions(string q)
    {
        q = Normalize(q);

        if (q.Length < 2)
        {
            return Json(new
            {
                titles = Array.Empty<object>(),
                genres = Array.Empty<object>(),
                authorPublishers = Array.Empty<object>()
            });
        }

        var suggestions = await _cache.GetOrCreateAsync(
            CacheKeys.BookSearchSuggestions(q.ToLowerInvariant()),
            async () =>
            {
                var criteria = new BookSearchCriteriaDto
                {
                    Title = q,
                };

                var books = (await _bookService.GetFilteredAsync(criteria))?.ToList()
                            ?? new List<BookSummaryDto>();

                if (books.Count == 0)
                {
                    var allSummaries = await _bookService.GetFilteredAsync(new BookSearchCriteriaDto());

                    books = allSummaries
                        .Where(b =>
                            ContainsCI(b.Title, q) ||
                            ContainsCI(b.AuthorName, q) ||
                            ContainsCI(b.PublisherName, q) ||
                            (b.Genres?.Any(g => ContainsCI(g.GenreName, q)) ?? false)
                        )
                        .Take(30)
                        .ToList();
                }

                var titles = books
                    .Where(b => ContainsCI(b.Title, q))
                    .Take(6)
                    .Select(b => new
                    {
                        id = b.Id,
                        text = b.Title,
                        meta = $"{b.AuthorName} • {b.PublisherName}"
                    })
                    .ToList();

                var genres = books
                    .SelectMany(b => b.Genres ?? Enumerable.Empty<BL.DTOs.GenreBookDTOs.GenreBookSummaryDto>())
                    .Select(g => g.GenreName)
                    .Where(name => !string.IsNullOrWhiteSpace(name) && ContainsCI(name, q))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Take(6)
                    .Select(name => new { text = name })
                    .ToList();

                var authors = books
                    .Select(b => b.AuthorName)
                    .Where(name => !string.IsNullOrWhiteSpace(name) && ContainsCI(name, q))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Take(3)
                    .Select(name => new { text = name, kind = "author" });

                var publishers = books
                    .Select(b => b.PublisherName)
                    .Where(name => !string.IsNullOrWhiteSpace(name) && ContainsCI(name, q))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Take(3)
                    .Select(name => new { text = name, kind = "publisher" });

                return new
                {
                    titles,
                    genres,
                    authorPublishers = authors.Concat(publishers).Take(6).ToList()
                };
            }
        );

        return Json(suggestions.ValueOrDefault);
    }

    private static string Normalize(string? q)
    {
        q ??= string.Empty;
        q = q.Trim();
        while (q.Contains("  "))
        {
            q = q.Replace("  ", " ");
        }
        return q;
    }

    private static bool ContainsCI(string? haystack, string needle)
    {
        if (string.IsNullOrWhiteSpace(haystack))
        {
            return false;
        }

        return haystack.Contains(needle, StringComparison.OrdinalIgnoreCase);
    }
}
