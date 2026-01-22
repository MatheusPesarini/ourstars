using Microsoft.EntityFrameworkCore;
using ourstars_back.Models;

namespace ourstars_back.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
    }
}
