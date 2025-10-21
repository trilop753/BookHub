using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BookReview : BaseEntity
    {
        public int Stars { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book? Book { get; set; }
    }
}
