using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class User : BaseEntity
    {
        [MinLength(1), MaxLength(15)]
        public string Username { get; set; }

        [MinLength(1), MaxLength(20)]
        public string Email { get; set; }

        //public string PasswordHash { get; set; }

        //public string PasswordSalt { get; set; }

        public bool IsBanned { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public virtual IEnumerable<WishlistItem> Wishlist { get; set; }

        public virtual IEnumerable<CartItem> CartItems { get; set; }

        public virtual IEnumerable<BookReview> Reviews { get; set; }
    }
}
