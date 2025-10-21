using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;
using Business.DTOs.AuthorDTOs;
using DAL.Models;

namespace Business.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto MapToDto(this Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
                Books = author.Books.Select(b => b.MapToSummaryDto()).ToList(),
            };
        }

        public static AuthorSummaryDto MapToSummaryDto(this Author author)
        {
            return new AuthorSummaryDto
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
            };
        }
    }
}
