using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class BookHubDbContext : IdentityDbContext<LocalIdentityUser>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<WishlistItem> WishlistItem { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<GenreBook> GenreBooks { get; set; }
        public DbSet<Giftcard> Giftcard { get; set; }
        public DbSet<GiftcardCode> GiftcardCode { get; set; }

        public BookHubDbContext(DbContextOptions<BookHubDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<WishlistItem>(entity =>
            {
                entity
                    .HasOne(w => w.User)
                    .WithMany(u => u.Wishlist)
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(w => w.Book)
                    .WithMany()
                    .HasForeignKey(w => w.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity
                    .HasOne(c => c.User)
                    .WithMany(c => c.Cart)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(c => c.Book)
                    .WithMany()
                    .HasForeignKey(c => c.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity
                    .HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity
                    .HasOne(oi => oi.Order)
                    .WithMany(o => o.Items)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<GenreBook>(entity =>
            {
                entity
                    .HasOne(gb => gb.Book)
                    .WithMany(b => b.Genres)
                    .HasForeignKey(gb => gb.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(gb => gb.Genre)
                    .WithMany(g => g.Books)
                    .HasForeignKey(gb => gb.GenreId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasIndex(gb => new { gb.BookId, gb.IsPrimary })
                    .IsUnique()
                    .HasFilter("[IsPrimary] = 1");
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedAll();
        }
    }
}
