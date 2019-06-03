using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGardner.Models
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Hex Sensor Id")]
        public string HexSensorId { get; set; }
        [DisplayName("Tree Sort")]
        public string TreeSort { get; set; }
        [DisplayName("X Coordinate")]
        public double XCoordinate { get; set; }
        [DisplayName("Y Coordinate")]
        public double YCoordinate { get; set; }

        public Location Location { get; set; }
        public int LocationId { get; set; }

    }
}
