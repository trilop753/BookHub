using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL.Data.Seed
{
    public static class GenreSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var genres = PrepareGenreModels();

            modelBuilder.Entity<Genre>()
                .HasData(genres);
        }

        private static List<Genre> PrepareGenreModels()
        {
            return new List<Genre>
            {
                new Genre { Id = 1, Name = "Fantasy" },
                new Genre { Id = 2, Name = "Horror" },
                new Genre { Id = 3, Name = "Science Fiction" },
                new Genre { Id = 4, Name = "Romance" },
                new Genre { Id = 5, Name = "Thriller" },
                new Genre { Id = 6, Name = "Biography" }
            };
        }
    }
}
