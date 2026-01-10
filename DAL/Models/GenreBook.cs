using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class GenreBook : BaseEntity
    {
        public int GenreId { get; set; }

        public int BookId { get; set; }

        public bool IsPrimary { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }
    }
}
