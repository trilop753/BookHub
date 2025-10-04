using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(BookHubDbContext context) : base(context)
        {
        }

        //public async Task<IEnumerable<Book>> findByAuthor(Author author)
        //{
        //    return await _dbSet.Where(book => book.Author == author).ToListAsync();
        //}

        //public async Task<IEnumerable<Book>> findByPublisher(Publisher publisher)
        //{
        //    return await _dbSet.Where(book => book.Publisher == publisher).ToListAsync();
        //}


        public async Task<IEnumerable<Book>> getBooksAsync(int[]? bookIds = null, bool includeAuthor = true, bool includePublisher = true,
            bool includeGenres = true, bool includeReviews = true)
        {
            IQueryable<Book> query = getBasicQuery(includeAuthor, includePublisher, includeGenres, includeReviews);

            if (bookIds != null && bookIds.Length > 0)
            {
                query.Where(b => bookIds.Contains(b.Id));
            }

            return await query.ToListAsync();
        }

        private IQueryable<Book> getBasicQuery(bool includeAuthor, bool includePublisher, bool includeGenres, bool includeReviews)
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
