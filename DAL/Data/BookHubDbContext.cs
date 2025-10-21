using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class BookHubDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public BookHubDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO add restrictions on properties length?
            modelBuilder.Entity<Book>(entity =>
            {
                entity
                    .HasOne(b => b.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(b => b.PublisherId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasMany(b => b.Reviews)
                    .WithOne(r => r.Book)
                    .HasForeignKey(r => r.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity
                    .HasMany(a => a.Books)
                    .WithOne(b => b.Author)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity
                    .HasMany(p => p.Books)
                    .WithOne(b => b.Publisher)
                    .HasForeignKey(b => b.PublisherId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasMany(g => g.Books).WithMany(b => b.Genres);
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedAll();
        }
    }
}
