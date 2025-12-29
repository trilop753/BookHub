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
        IAppCache cache
    )
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
            return Json(
                new
                {
                    titles = Array.Empty<object>(),
                    genres = Array.Empty<object>(),
                    authorPublishers = Array.Empty<object>(),
                }
            );
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
        var criteria = new BookSearchCriteriaDto { Query = q, SearchMode = BookSearchMode.Or };

        var titles = (await _bookService.GetFilteredAsync(criteria))
            .Take(6)
            .Select(b => new
            {
                id = b.Id,
                text = b.Title,
                meta = $"{b.AuthorName} • {b.PublisherName}",
            })
            .ToList();

        var genres = (await _genreService.GetGenresByNameAsync(q))
            .Take(6)
            .Select(g => new { text = g.Name })
            .ToList();

        var authors = (await _authorService.GetAuthorsByNameAsync(q))
            .Take(3)
            .Select(a => new { text = $"{a.Name} {a.Surname}", kind = "author" })
            .ToList();

        var publishers = (await _publisherService.GetPublishersByNameAsync(q))
            .Take(3)
            .Select(p => new { text = p.Name, kind = "publisher" })
            .ToList();

        return new
        {
            titles,
            genres,
            authorPublishers = authors.Concat(publishers).ToList(),
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
}
