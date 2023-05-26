using RectangleONEHSN.Model;

namespace RectangleONEHSN.Data
{
    public class DataSeeder
    {
        private readonly AppDbContext _dbContext;

        public DataSeeder(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Populates the database with 200 rectangle entries with random values
        /// </summary>
        public void SeedData()
        {
            //check if there is data
            if (!_dbContext.Rectangles.Any())
            {
                var random = new Random();

                for (int i = 0; i < 200; i++)
                {
                    var rectangle = new Rectangle
                    {
                        X = random.Next(0, 100),
                        Y = random.Next(0, 100),
                        Width = random.Next(1, 10),
                        Height = random.Next(1, 10)
                    };

                    _dbContext.Rectangles.Add(rectangle);
                }

                _dbContext.SaveChanges();
            }
        }
    }

}
