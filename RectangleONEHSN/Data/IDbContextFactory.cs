namespace RectangleONEHSN.Data
{
    public interface IDbContextFactory
    {
        IAppDbContext CreateDbContext();
    }
}
