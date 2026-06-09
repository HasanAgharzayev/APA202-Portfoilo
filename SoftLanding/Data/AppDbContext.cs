using Microsoft.EntityFrameworkCore;
using SoftLanding.Models;

namespace SoftLanding.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }

    }
}
