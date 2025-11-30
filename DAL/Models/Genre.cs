namespace DAL.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<GenreBook> Books { get; set; } = new HashSet<GenreBook>();
    }
}
