using Microsoft.AspNetCore.Mvc;
using RectangleONEHSN.Data;
using RectangleONEHSN.Model;

namespace RectangleONEHSN.Controllers
{
    [Route("api/rectangle")]
    [ApiController]
    public class RectangleController : Controller
    {

        private readonly AppDbContext _dbContext;

        public RectangleController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
                
        /// <summary>
        /// Method that return the list of rentacles baes on the provided coordinates
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        [HttpPost("coordinates")]
        public ActionResult<IEnumerable<Rectangle>> GetRectanglesForCoordinates([FromBody] int[][] coordinates)
        {
            //check if coordinates are null, 0 or lenght is different of two
            if (coordinates == null || coordinates.Length == 0 || coordinates.Any(c => c.Length != 2))
            {
                return BadRequest("Invalid coordinates format. Please provide an array of coordinate pairs, where each pair contains two numbers.");
            }

            List<Rectangle> rectangles = new List<Rectangle>();

            foreach (var coordinate in coordinates)
            {
                int x = coordinate[0];
                int y = coordinate[1];

                var matchingRectangles = _dbContext.Rectangles
                    .Where(r => x >= r.X && x <= r.X + r.Width && y >= r.Y && y <= r.Y + r.Height)
                    .ToList();

                rectangles.AddRange(matchingRectangles);
            }

            return Ok(rectangles);
        }


    }
}
