using Business.DTOs.GenreDTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto mapToDto(this Genre genre)
        {
            GenreDto dto = new GenreDto();
            dto.Id = genre.Id;
            dto.Name = genre.Name;
            dto.Books = genre.Books.Select(b => b.mapToSummaryDto()).ToList();
            return dto;
        }

        public static GenreSummaryDto mapToSummary(this Genre genre)
        {
            GenreSummaryDto summaryDto = new GenreSummaryDto();
            summaryDto.Id = genre.Id;
            summaryDto.Name = genre.Name;
            return summaryDto;
        }

    }
}
