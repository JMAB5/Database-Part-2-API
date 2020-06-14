using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Inventory7588
    {
        public int Productid { get; set; }
        public string Locationid { get; set; }
        public int Numinstock { get; set; }

        public virtual Location7588 Location { get; set; }
        public virtual Product7588 Product { get; set; }
    }
}