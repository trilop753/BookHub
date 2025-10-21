namespace DAL.UtilityModels
{
	public class BookSearchCriteria
	{
		/// <summary>
		/// Books that contain the provided title text in their Title.
		/// Case insensitive.
		/// </summary>
		public string? Title { get; set; }

		/// <summary>
		/// Books that contain the provided description text in their Description.
		/// Case insensitive.
		/// </summary>
		public string? Description { get; set; }

		public decimal? LowPrice { get; set; }

		public decimal? HighPrice { get; set; }

		/// <summary>
		/// Books that contain at least one of the provided genres.
		/// </summary>
		public int[]? GenreIds { get; set; }

		public int? AuthorId { get; set; }

		public int? PublisherId { get; set; }
	}
}
