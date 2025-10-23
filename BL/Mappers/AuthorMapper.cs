using BL.DTOs.AuthorDTOs;
using DAL.Models;

namespace BL.Mappers
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
