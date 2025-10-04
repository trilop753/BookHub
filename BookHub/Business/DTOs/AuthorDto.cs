using DAL.Models;

namespace Business.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public virtual IEnumerable<BookDto> Books { get; set; }
    }
}