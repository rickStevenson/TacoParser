using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoParcer
{
    public class Location : ILocation
    {
        public string Name {  get; set; }
        public Point Location {  get; set; }
    }
}
