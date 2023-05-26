using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using RectangleONEHSN.Controllers;
using RectangleONEHSN.Data;
using RectangleONEHSN.Model;
using Xunit;

namespace RectangleAPI.Tests
{
    public class RectangleControllerTests
    {
        private readonly Mock<IAppDbContext> _dbContextMock;

        public RectangleControllerTests()
        {
            // Initialize the mock object
            _dbContextMock = new Mock<IAppDbContext>();
        }


        /// <summary>
        /// Test if providing coordenates it returns a result
        /// </summary>
        [Fact]
        public void GetRectanglesForCoordinates_ReturnsRectanglesForValidCoordinates()
        {
            // Arrange
            // Set up the mock DbContext to return a list of rectangles for a specific test scenario
            var mockRectangles = new List<Rectangle>
            {
                new Rectangle { X = 0, Y = 0, Width = 10, Height = 10 },
                new Rectangle { X = 10, Y = 10, Width = 20, Height = 20 }
            };

            // Create a DbSet mock using the list
            var mockDbSet = new Mock<DbSet<Rectangle>>();
            mockDbSet.As<IQueryable<Rectangle>>().Setup(m => m.Provider).Returns(mockRectangles.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Rectangle>>().Setup(m => m.Expression).Returns(mockRectangles.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Rectangle>>().Setup(m => m.ElementType).Returns(mockRectangles.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Rectangle>>().Setup(m => m.GetEnumerator()).Returns(mockRectangles.AsQueryable().GetEnumerator());

            // Setup the DbContext mock to return the DbSet mock
            _dbContextMock.Setup(db => db.Rectangles).Returns(mockDbSet.Object);

            // Create an instance of the controller, passing the mock DbContext
            var controller = new RectangleController(_dbContextMock.Object);

            // Act
            // Invoke the API endpoint 
            var result = controller.GetRectanglesForCoordinates(new int[][] { new int[] { 5, 5 } });

            // Assert
            // Perform assertions on the returned result
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var rectangles = Assert.IsAssignableFrom<IEnumerable<Rectangle>>(okResult.Value);
            Assert.Equal(1, rectangles.Count());
        }

        /// <summary>
        /// Check if providing wrong parameters returns a BadRequest
        /// </summary>
        [Fact]        
        public void GetRectanglesForCoordinates_ReturnsBadRequestForInvalidCoordinates()
        {
            // Arrange
            var controller = new RectangleController(_dbContextMock.Object);

            // Act
            var result = controller.GetRectanglesForCoordinates(new int[][] { new int[] { 5 } });

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Invalid coordinates format. Please provide an array of coordinate pairs, where each pair contains two numbers.", badRequestResult.Value);
        }
    }
}
