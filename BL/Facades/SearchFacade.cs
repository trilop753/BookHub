using BL.DTOs.BookDTOs;
using BL.DTOs.UtilityDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;

namespace BL.Facades
{
    public class SearchFacade : ISearchFacade
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly IGenreService _genreService;

        public SearchFacade(
            IBookService bookService,
            IAuthorService authorService,
            IPublisherService publisherService,
            IGenreService genreService
        )
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            _genreService = genreService;
        }

        public async Task<SearchResultDto> QuerySearch(string query, SearchMode mode)
        {
            var criteria = new BookSearchCriteriaDto { Query = query, SearchMode = mode };

            var books = (await _bookService.GetFilteredAsync(criteria)).ToList();

            var genres = (await _genreService.GetGenresByNameAsync(query)).ToList();

            var authors = (await _authorService.GetAuthorsByNameAsync(query)).ToList();

            var publishers = (await _publisherService.GetPublishersByNameAsync(query)).ToList();

            return new SearchResultDto()
            {
                Books = books,
                Genres = genres,
                Authors = authors,
                Publishers = publishers,
            };
        }
    }
}
