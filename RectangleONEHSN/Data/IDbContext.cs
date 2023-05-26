using RectangleONEHSN.Model;

namespace RectangleONEHSN.Data
{
    public interface IDbContext
    {
        IQueryable<Rectangle> Rectangles { get; }
    }
}