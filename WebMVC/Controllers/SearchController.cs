using BL.DTOs.UtilityDTOs;
using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;

namespace WebMVC.Controllers;

public class SearchController : Controller
{
    private readonly ISearchFacade _searchFacade;
    private readonly IAppCache _cache;

    public SearchController(ISearchFacade searchFacade, IAppCache cache)
    {
        _searchFacade = searchFacade;
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
        var res = await _searchFacade.QuerySearch(q, SearchMode.Or);

        var titles = res
            .Books.Take(6)
            .Select(b => new
            {
                id = b.Id,
                text = b.Title,
                meta = $"{b.AuthorName} • {b.PublisherName}",
            })
            .ToList();

        var genres = res.Genres.Take(6).Select(g => new { text = g.Name }).ToList();

        var authors = res
            .Authors.Take(3)
            .Select(a => new { text = $"{a.Name} {a.Surname}", kind = "author" })
            .ToList();

        var publishers = res
            .Publishers.Take(3)
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
