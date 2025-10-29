namespace DAL.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
