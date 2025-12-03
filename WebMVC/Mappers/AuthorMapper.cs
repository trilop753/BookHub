using BL.DTOs.AuthorDTOs;
using WebMVC.Models.Author;

namespace WebMVC.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorViewModel MapToView(this AuthorSummaryDto author)
        {
            return new AuthorViewModel()
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
            };
        }

        public static AuthorViewModel MapToView(this AuthorDto author)
        {
            return new AuthorViewModel()
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
            };
        }
    }
}
