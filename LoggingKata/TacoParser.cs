namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                logger.LogInfo("array length less than 3");
                return null; 
            }
            // Done: Grab the latitude from your array at index 0
            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            
             double lat = double.Parse(cells[0]);
            
            // Done: Grab the longitude from your array at index 1
            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            
            double lon = double.Parse(cells[1]);
            
            // Done: Grab the name from your array at index 2
            
            string cityName = cells[2];

            // Done: Create a TacoBell class
            // that conforms to ITrackable

            // Done: Create an instance of the Point Struct
            var point = new Point();

            // Done: Set the values of the point correctly (Latitude and Longitude) 
            point.Latitude = lat;
            point.Longitude = lon;

            // Done: Create an instance of the TacoBell class
            var tacoBell = new TacoBell();

            // Done: Set the values of the class correctly (Name and Location)
            tacoBell.Name = cityName;
            tacoBell.Location = point;

            // Done: Then, return the instance of your TacoBell class,
            // since it conforms to ITrackable

            return tacoBell;
        }
    }
}
