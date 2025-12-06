using DAL.Data;
using DAL.Models;
using DAL.UtilityModels;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<IEnumerable<Book>> GetBooksAsync(
            int[]? bookIds = null,
            bool includeAuthor = true,
            bool includePublisher = true,
            bool includeGenres = true,
            bool includeReviews = true
        )
        {
            IQueryable<Book> query = GetBasicQuery(
                includeAuthor,
                includePublisher,
                includeGenres,
                includeReviews
            );

            if (bookIds != null)
            {
                query = query.Where(b => bookIds.Contains(b.Id));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetFilteredAsync(BookSearchCriteria searchCriteria)
        {
            searchCriteria ??= new BookSearchCriteria();

            IQueryable<Book> query = GetBasicQuery(
                includeAuthor: true,
                includePublisher: true,
                includeGenres: true,
                includeReviews: false
            );


            if (searchCriteria.LowPrice.HasValue)
            {
                query = query.Where(b => b.Price > searchCriteria.LowPrice.Value);
            }

            if (searchCriteria.HighPrice.HasValue)
            {
                query = query.Where(b => b.Price <= searchCriteria.HighPrice.Value);
            }

            var title = Normalize(searchCriteria.Title);
            var desc = Normalize(searchCriteria.Description);
            var q = Normalize(searchCriteria.Query);

            if (!string.IsNullOrWhiteSpace(q))
            {
                title ??= q;
                desc ??= q;
            }

            var hasTitle = !string.IsNullOrWhiteSpace(title);
            var hasDesc = !string.IsNullOrWhiteSpace(desc);
            var hasGenres = searchCriteria.GenreIds is { Length: > 0 };
            var hasAuthor = searchCriteria.AuthorId.HasValue;
            var hasPublisher = searchCriteria.PublisherId.HasValue;

            if (searchCriteria.SearchMode == BookSearchMode.And)
            {
                if (hasTitle)
                {
                    query = query.Where(b => EF.Functions.Like(b.Title, $"%{title}%"));
                }

                if (hasDesc)
                {
                    query = query.Where(b => EF.Functions.Like(b.Description, $"%{desc}%"));
                }

                if (hasGenres)
                {
                    var ids = searchCriteria.GenreIds!;
                    query = query.Where(b => b.Genres.Any(gb => ids.Contains(gb.Genre.Id)));
                }

                if (hasAuthor)
                {
                    var authorId = searchCriteria.AuthorId!.Value;
                    query = query.Where(b => b.AuthorId == authorId);
                }

                if (hasPublisher)
                {
                    var publisherId = searchCriteria.PublisherId!.Value;
                    query = query.Where(b => b.PublisherId == publisherId);
                }
            }
            else
            {
                query = query.Where(b =>
                    (hasTitle && EF.Functions.Like(b.Title, $"%{title}%")) ||
                    (hasDesc && EF.Functions.Like(b.Description, $"%{desc}%")) ||
                    (hasGenres && b.Genres.Any(gb => searchCriteria.GenreIds!.Contains(gb.Genre.Id))) ||
                    (hasAuthor && b.AuthorId == searchCriteria.AuthorId!.Value) ||
                    (hasPublisher && b.PublisherId == searchCriteria.PublisherId!.Value)
                );
            }

            return await query.ToListAsync();
        }

        private static string? Normalize(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value.Trim();
        }


        public async Task<Book?> GetBookByIdWithGenresIncludedAsync(int bookId)
        {
            IQueryable<Book> query = _dbSet
                .Where(book => book.Id == bookId)
                .Include(book => book.Genres);
            return await query.FirstOrDefaultAsync();
        }

        private IQueryable<Book> GetBasicQuery(
            bool includeAuthor,
            bool includePublisher,
            bool includeGenres,
            bool includeReviews
        )
        {
            IQueryable<Book> bookQuery = _dbSet;

            if (includeAuthor)
            {
                bookQuery = bookQuery.Include(b => b.Author);
            }
            if (includePublisher)
            {
                bookQuery = bookQuery.Include(b => b.Publisher);
            }
            if (includeGenres)
            {
                bookQuery = bookQuery.Include(b => b.Genres);
            }
            if (includeReviews)
            {
                bookQuery = bookQuery.Include(b => b.Reviews);
            }

            return bookQuery;
        }
    }
}
