using Business.DTOs;
using Business.DTOs.AuthorDTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto MapToDto(this Author author)
        {
            AuthorDto dto = new AuthorDto();
            dto.Id = author.Id;
            dto.Name = author.Name;
            dto.Surname = author.Surname;
            dto.Books = author.Books.Select(b => b.MapToSummaryDto()).ToList();
            return dto;
        }

        public static AuthorSummaryDto MapToSummaryDto(this Author author)
        {
            AuthorSummaryDto dtoSummary = new AuthorSummaryDto();
            dtoSummary.Id = author.Id;
            dtoSummary.Name = author.Name;
            dtoSummary.Surname = author.Surname;
            return dtoSummary;
        }
    }
}
