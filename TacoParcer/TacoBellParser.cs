namespace TacoParcer
{
    public class TacoBellParser
    {
        readonly ILog logger = new Logger();
        
        public ILocation Parse(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                logger.LogInfo("array length less than 3");
                return null; 
            }
            
            double lat = double.Parse(cells[0]);
            double lon = double.Parse(cells[1]);
            
            string cityName = cells[2];

            var point = new Point();

            point.Latitude = lat;
            point.Longitude = lon;

            var tacoBell = new Location();

            tacoBell.Name = cityName;
            tacoBell.Location = point;

            return tacoBell;
        }
    }
}
