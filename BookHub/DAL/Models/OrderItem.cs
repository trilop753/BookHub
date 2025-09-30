using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class OrderItem: BaseEntity
	{
		public int Quantity { get; set; }

		public int OrderId { get; set; }

		public int BookId { get; set; }

		[ForeignKey(nameof(OrderId))]
		public virtual Order? Order { get; set; }

		[ForeignKey(nameof(BookId))]
        public virtual Book? Book { get; set; }

    }
}
