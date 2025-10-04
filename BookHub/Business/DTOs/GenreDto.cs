using DAL.Models;

namespace Business.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<BookDto> Books { get; set; }
    }
}