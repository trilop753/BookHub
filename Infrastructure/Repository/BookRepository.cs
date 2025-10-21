using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

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

            if (bookIds != null && bookIds.Length > 0)
            {
                query.Where(b => bookIds.Contains(b.Id));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetFiltered(
            string? title,
            string? dsc,
            decimal? lowPrice,
            decimal? highPrice,
            int[]? genreIds,
            int? authorId,
            int? publisherId
        )
        {
            // Horrific, but I can't send BookSearchCriteriaDTO since
            // that would require linking Business and Infrastructure,
            // which is forbidden since it would create a circular dependancy

            // Separate SearchCriteria model for DAL?

            IQueryable<Book> query = _dbSet;

            if (title != null)
            {
                query = query.Where(b => b.Title.ToLower().Contains(title.ToLower()));
            }

            if (dsc != null)
            {
                query = query.Where(b => b.Description.ToLower().Contains(dsc.ToLower()));
            }

            if (lowPrice != null)
            {
                query = query.Where(b => b.Price > lowPrice);
            }

            if (highPrice != null)
            {
                query = query.Where(b => b.Price <= highPrice);
            }

            if (genreIds != null)
            {
                query = query.Where(b => b.Genres.Select(g => g.Id).Intersect(genreIds).Any());
            }

            if (authorId != null)
            {
                query = query.Where(b => b.AuthorId == authorId);
            }

            if (publisherId != null)
            {
                query = query.Where(b => b.PublisherId == publisherId);
            }

            return await query.ToListAsync();
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
