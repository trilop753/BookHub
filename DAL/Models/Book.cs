using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public virtual IEnumerable<Genre> Genres { get; set; } = new HashSet<Genre>();

        public int PublisherId { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public virtual Publisher? Publisher { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual Author? Author { get; set; }

        public virtual IEnumerable<BookReview> Reviews { get; set; }

        public int EditCount { get; set; } = 0;

        public int? LastEditedById { get; set; }

        [ForeignKey(nameof(LastEditedById))]
        public virtual User? LastEditedBy { get; set; }
    }
}
