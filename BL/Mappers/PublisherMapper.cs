using BL.DTOs;
using BL.DTOs.PublisherDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class PublisherMapper
    {
        public static PublisherDto MapToDto(this Publisher publisher)
        {
            return new PublisherDto
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Books = (publisher.Books ?? new List<Book>())
                    .Select(b => b.MapToSummaryDto())
                    .ToList(),
            };
        }

        public static PublisherSummaryDto MapToSummaryDto(this Publisher publisher)
        {
            return new PublisherSummaryDto { Id = publisher.Id, Name = publisher.Name };
        }
    }
}
