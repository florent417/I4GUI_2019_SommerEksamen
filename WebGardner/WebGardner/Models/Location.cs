using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGardner.Models
{
    public class Location
    {
        [Key]
        [DisplayName("Location Id")]
        public int LocationId { get; set; }
        [DisplayName("Location")]
        public string LocationName { get; set; }
        [DisplayName("Street Name")]
        public string LocationStreet { get; set; }
        [DisplayName("Street Number")]
        public int StreetNbr { get; set; }
        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }
        public string City { get; set; }

        public List<Tree> Trees { get; set; }

        public List<Sensor> Sensors { get; set; }

    }
}
