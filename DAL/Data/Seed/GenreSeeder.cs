using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
    public static class GenreSeeder
    {
        public static List<Genre> Seed(this ModelBuilder modelBuilder)
        {
            var genres = PrepareGenreModels();
            modelBuilder.Entity<Genre>().HasData(genres);
            return genres;
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
