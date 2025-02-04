using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.ComponentModel.DataAnnotations;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            logger.LogInfo($"Lines: {lines[0]}");
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();

            foreach (var location in locations)
            {
                Console.WriteLine($"{location.Name} {location.Location.Latitude} {location.Location.Longitude}");
            }

            ITrackable taco1 = null;
            ITrackable taco2 = null;
           
            double tacoDistance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate
                {
                    Latitude = locA.Location.Latitude, 
                    Longitude = locA.Location.Longitude 
                };
                for (int j = i + 1; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };
                    double currentDistance = corA.GetDistanceTo(corB);
                    if (currentDistance > tacoDistance)
                    {
                        tacoDistance = currentDistance;
                        taco1 = locA;
                        taco2 = locB;
                    }
                }
            }
            Console.WriteLine($"The two Taco Bells farthest apart are {taco1.Name} and {taco2.Name}, with a distance of {tacoDistance / 1000} kilometers.");
        }
    }
}
