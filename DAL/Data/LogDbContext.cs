using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options)
            : base(options) { }

        public DbSet<LogEntry> Logs { get; set; }
    }
}
