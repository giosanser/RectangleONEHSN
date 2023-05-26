using Microsoft.EntityFrameworkCore;
using RectangleONEHSN.Model;

namespace RectangleONEHSN.Data
{
    public interface IAppDbContext
    {
        DbSet<Rectangle> Rectangles { get; set; }

    }

    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Rectangle> Rectangles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
