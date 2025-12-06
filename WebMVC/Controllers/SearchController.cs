using BL.DTOs.BookDTOs;
using BL.Services.Interfaces;
using DAL.UtilityModels;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;

namespace WebMVC.Controllers;

public class SearchController : Controller
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    private readonly IPublisherService _publisherService;
    private readonly IGenreService _genreService;
    private readonly IAppCache _cache;

    public SearchController(
        IBookService bookService,
        IAuthorService authorService,
        IPublisherService publisherService,
        IGenreService genreService,
        IAppCache cache)
    {
        _bookService = bookService;
        _authorService = authorService;
        _publisherService = publisherService;
        _genreService = genreService;
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
            () => BuildSuggestionsAsync(q)
        );

        return Json(suggestions.ValueOrDefault);
    }

    private async Task<object> BuildSuggestionsAsync(string q)
    {
        // BOOKS: DB-side OR search via your updated repository logic
        var criteria = new BookSearchCriteriaDto
        {
            Query = q,
            SearchMode = BookSearchMode.Or
        };

        var books = (await _bookService.GetFilteredAsync(criteria))
            .Take(30)
            .ToList();

        var titles = books
            .Where(b => ContainsCi(b.Title, q))
            .Take(6)
            .Select(b => new
            {
                id = b.Id,
                text = b.Title,
                meta = $"{b.AuthorName} • {b.PublisherName}"
            })
            .ToList();

        // GENRES/AUTHORS/PUBLISHERS: independent of books (even if 0 books)
        var genres = (await _genreService.GetAllGenresAsync())
            .Select(g => g.Name)
            .Where(name => !string.IsNullOrWhiteSpace(name) && ContainsCi(name, q))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Take(6)
            .Select(name => new { text = name })
            .ToList();

        var authors = (await _authorService.GetAllAuthorsAsync())
            .Select(a => $"{a.Name} {a.Surname}".Trim())
            .Where(full => !string.IsNullOrWhiteSpace(full) && ContainsCi(full, q))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Take(3)
            .Select(full => new { text = full, kind = "author" })
            .ToList();

        var publishers = (await _publisherService.GetAllPublishersAsync())
            .Select(p => p.Name)
            .Where(name => !string.IsNullOrWhiteSpace(name) && ContainsCi(name, q))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Take(3)
            .Select(name => new { text = name, kind = "publisher" })
            .ToList();

        return new
        {
            titles,
            genres,
            authorPublishers = authors.Concat(publishers).Take(6).ToList()
        };
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

    private static bool ContainsCi(string? haystack, string needle)
    {
        if (string.IsNullOrWhiteSpace(haystack))
        {
            return false;
        }

        return haystack.Contains(needle, StringComparison.OrdinalIgnoreCase);
    }
}
