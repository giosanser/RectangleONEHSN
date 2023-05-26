using Microsoft.EntityFrameworkCore;

namespace RectangleONEHSN.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public DbContextFactory(DbContextOptions<AppDbContext> options)
        {
            _options = options;
        }

        public IAppDbContext CreateDbContext()
        {
            return new AppDbContext(_options);
        }
    }
}
