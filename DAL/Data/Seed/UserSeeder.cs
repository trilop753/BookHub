using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL.Data.Seed
{
    public static class UserSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = PrepareUserModels();

            modelBuilder.Entity<User>()
                .HasData(users);
        }

        private static List<User> PrepareUserModels()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@bookhub.com",
                    PasswordHash = "hash_admin",
                    PasswordSalt = "salt_admin",
                    IsBanned = false
                },
                new User
                {
                    Id = 2,
                    Username = "john",
                    Email = "john.doe@gmail.com",
                    PasswordHash = "hash_john",
                    PasswordSalt = "salt_john",
                    IsBanned = false
                },
                new User
                {
                    Id = 3,
                    Username = "emma",
                    Email = "emma.reader@gmail.com",
                    PasswordHash = "hash_emma",
                    PasswordSalt = "salt_emma",
                    IsBanned = false
                },
                new User
                {
                    Id = 4,
                    Username = "mike",
                    Email = "mike.writer@gmail.com",
                    PasswordHash = "hash_mike",
                    PasswordSalt = "salt_mike",
                    IsBanned = false
                }
            };
        }
    }
}
