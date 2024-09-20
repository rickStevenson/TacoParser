using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.057823,-84.592806,Taco Bell Kennesaw...", -84.592806)]
        [InlineData("34.720804,-85.280165,Taco Bell La Fayett...", -85.280165)]
        [InlineData("33.051273,-85.028938, Taco Bell Lagrang...", -85.028938)]
        [InlineData("33.889469,-84.057706, Taco Bell Lawrenceville...", -84.057706)]
        [InlineData("33.951387,-84.061032, Taco Bell Lawrenceville...", -84.061032)]
        [InlineData("33.965479,-84.007838, Taco Bell Lawrenceville...", -84.007838)]

        public void ShouldParseLongitude(string line, double expected)
        {
            // Done: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();
            //Act
            ITrackable result = tacoParser.Parse(line); // Parse the line into an ITrackable object
            double actual = result.Location.Longitude;  // Extract the Longitude from the Location property
            //Assert
            Assert.Equal(expected, actual);
        }


        //Done: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.057823,-84.592806,Taco Bell Kennesaw...", 34.057823)]
        [InlineData("34.720804,-85.280165,Taco Bell La Fayett...", 34.720804)]
        [InlineData("33.051273,-85.028938, Taco Bell Lagrang...", 33.051273)]
        [InlineData("33.889469,-84.057706, Taco Bell Lawrenceville...", 33.889469)]
        [InlineData("33.951387,-84.061032, Taco Bell Lawrenceville...", 33.951387)]
        [InlineData("33.965479,-84.007838, Taco Bell Lawrenceville...", 33.965479)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            ITrackable result = tacoParser.Parse(line);
            double actual = result.Location.Latitude;
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
