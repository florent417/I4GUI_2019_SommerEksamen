using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGardner.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string HexSensId { get; set; }
        public string TreeSort { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }


        public Location Location { get; set; }
        public int LocationId { get; set; }
    }
}
