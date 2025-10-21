using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Task<IEnumerable<Book>> GetBooksAsync(
            int[]? bookIds = null,
            bool includeAuthor = true,
            bool includePublisher = true,
            bool includeGenres = true,
            bool includeReviews = true
        );

        /// <summary>
        /// Returns books filtered according to provided filters.
        /// </summary>
        /// <param name="title">Books that contain the provided title text in their Title. Case insensitive.</param>
        /// <param name="dsc">Books that contain the provided desc text in their Description. Case insensitive.</param>
        /// <param name="lowPrice"></param>
        /// <param name="highPrice"></param>
        /// <param name="genreIds">Books that have at least one of the specified genres.</param>
        /// <param name="authorId"></param>
        /// <param name="publisherId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Book>> GetFiltered(
            string? title,
            string? dsc,
            decimal? lowPrice,
            decimal? highPrice,
            int[]? genreIds,
            int? authorId,
            int? publisherId
        );
    }
}
