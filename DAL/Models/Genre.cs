namespace DAL.Models
{
	public class Genre : BaseEntity
	{
		public string Name { get; set; }

		public virtual IEnumerable<Book> Books { get; set; }
	}
}
