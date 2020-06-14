using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Location7588
    {
        public Location7588()
        {
            Inventory7588 = new HashSet<Inventory7588>();
            Purchaseorder7588 = new HashSet<Purchaseorder7588>();
        }

        public string Locationid { get; set; }
        public string Locname { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<Inventory7588> Inventory7588 { get; set; }
        public virtual ICollection<Purchaseorder7588> Purchaseorder7588 { get; set; }
    }
}