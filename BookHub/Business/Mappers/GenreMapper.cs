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
        public static GenreDto MapToDto(this Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                Books = genre.Books.Select(b => b.MapToSummaryDto()).ToList()
            };
        }

        public static GenreSummaryDto MapToSummaryDto(this Genre genre)
        {
            return new GenreSummaryDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

    }
}
