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


    }
}
