using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Task<IEnumerable<Book>> GetBooksIncludeAsync(int[]? bookIds = null, bool includeAuthor = true, bool includePublisher = true,
            bool includeGenres = true, bool includeReviews = true);
    }
}
