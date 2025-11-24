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
            IQueryable<Book> query = _dbSet;

            if (searchCriteria.Title != null)
            {
                query = query.Where(b =>
                    b.Title.ToLower().Contains(searchCriteria.Title.ToLower())
                );
            }

            if (searchCriteria.Description != null)
            {
                query = query.Where(b =>
                    b.Description.ToLower().Contains(searchCriteria.Description.ToLower())
                );
            }

            if (searchCriteria.LowPrice != null)
            {
                query = query.Where(b => b.Price > searchCriteria.LowPrice);
            }

            if (searchCriteria.HighPrice != null)
            {
                query = query.Where(b => b.Price <= searchCriteria.HighPrice);
            }

            if (searchCriteria.GenreIds != null)
            {
                query = query.Where(b =>
                    b.Genres.Select(g => g.Id).Intersect(searchCriteria.GenreIds).Any()
                );
            }

            if (searchCriteria.AuthorId != null)
            {
                query = query.Where(b => b.AuthorId == searchCriteria.AuthorId);
            }

            if (searchCriteria.PublisherId != null)
            {
                query = query.Where(b => b.PublisherId == searchCriteria.PublisherId);
            }

            return await query.ToListAsync();
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
