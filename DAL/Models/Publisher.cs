namespace DAL.Models
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}
