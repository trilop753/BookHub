using Bogus;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using static Bogus.DataSets.Name;

namespace DAL.Data.Seed
{
    public static class GenreSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var genres = PrepareGenreModels();
            modelBuilder.Entity<Genre>().HasData(genres);
        }

        private static List<Genre> PrepareGenreModels()
        {
            var genreNames = new[]
            {
                "Fantasy",
                "Horror",
                "Science Fiction",
                "Romance",
                "Thriller",
                "Mystery",
                "Biography",
                "Adventure",
            };

            return genreNames.Select((name, i) => new Genre { Id = i + 1, Name = name }).ToList();
        }
    }
}
