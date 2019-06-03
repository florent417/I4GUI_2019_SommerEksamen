using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGardner.Models
{
    public class Tree
    {
        [Key]
        public int TreeId { get; set; }
        [DisplayName("Tree Sort")]
        public string TreeSort { get; set; }
        public int Amount { get; set; }

        public Location Location { get; set; }
        public int LocationId { get; set; }

    }
}
