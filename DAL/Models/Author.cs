namespace DAL.Models
{
	public class Author : BaseEntity
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public virtual IEnumerable<Book> Books { get; set; }
	}
}
