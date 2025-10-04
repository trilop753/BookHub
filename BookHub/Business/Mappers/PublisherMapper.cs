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
            PublisherDto dto = new PublisherDto();
            dto.Id = publisher.Id;
            dto.Name = publisher.Name;
            dto.Books = publisher.Books.Select(b => b.MapToSummaryDto()).ToList();
            return dto;
        }

        public static PublisherSummaryDto MapToSummary(this Publisher publisher)
        {
            PublisherSummaryDto dtoSummary = new PublisherSummaryDto();
            dtoSummary.Id = publisher.Id;
            dtoSummary.Name = publisher.Name;
            return dtoSummary;
        }
    }
}
