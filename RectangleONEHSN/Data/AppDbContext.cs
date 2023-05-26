using Microsoft.EntityFrameworkCore;
using RectangleONEHSN.Model;

namespace RectangleONEHSN.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Rectangle> Rectangles { get; set; }

        
    }

}
