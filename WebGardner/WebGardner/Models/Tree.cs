using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebGardner.Models
{
    public class Tree
    {
        public int TreeId { get; set; }
        [DisplayName("Sort")]
        public string SortName { get; set; }
        public int Amount { get; set; }


        public Location Location { get; set; }
        public int LocationId { get; set; }
    }
}
