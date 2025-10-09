using Business.DTOs;
using Business.DTOs.PublisherDTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public static class PublisherMapper
    {
        public static PublisherDto MapToDto(this Publisher publisher)
        {
            return new PublisherDto
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Books = publisher.Books.Select(b => b.MapToSummaryDto()).ToList()
            };
        }

        public static PublisherSummaryDto MapToSummaryDto(this Publisher publisher)
        {
            return new PublisherSummaryDto
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }
    }
}
