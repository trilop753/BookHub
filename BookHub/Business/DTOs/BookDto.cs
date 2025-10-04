using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public PublisherDto Publisher { get; set; }

        public AuthorDto Author { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }

        public IEnumerable<BookReviewDto> Reviews { get; set; }
    }
}
