using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.BookDTOs
{
	public class BookSearchCriteriaDto
	{
		public string? Name { get; set; }

		public string? Description { get; set; }

		public decimal? LowPrice { get; set; }

		public decimal? HighPrice { get; set; }

		public int[]? GenreIds { get; set; }

		public int? AuthorId { get; set; }

		public int? PublisherId { get; set; }
	}
}
