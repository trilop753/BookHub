using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class User: BaseEntity
	{
		public string Username { get; set; }

		public string Email { get; set; }

		public string PasswordHash { get; set; }

		public string PasswordSalt { get; set; }

		public bool IsBanned { get; set; }
	}
}
