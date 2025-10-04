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
        public Task<IEnumerable<Book>> getBooksAsync(int[]? bookIds, bool includeAuthor, bool includePublisher, bool includeGenres, bool includeReviews);
    }
}
