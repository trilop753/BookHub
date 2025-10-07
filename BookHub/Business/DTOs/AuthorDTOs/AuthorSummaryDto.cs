using Business.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.AuthorDTOs
{
    public class AuthorSummaryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
