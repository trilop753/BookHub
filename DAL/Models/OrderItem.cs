using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        // Duplicate Book data to be independent
        // from Book table updates/deletes
        public string BookTitle { get; set; }

        public string BookISBN { get; set; }

        public decimal BookPrice { get; set; }

        public string BookPublisher { get; set; }

        public string BookAuthor { get; set; }
    }
}
