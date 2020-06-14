using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Product7588
    {
        public Product7588()
        {
            Inventory7588 = new HashSet<Inventory7588>();
            Orderline7588 = new HashSet<Orderline7588>();
            Purchaseorder7588 = new HashSet<Purchaseorder7588>();
        }

        public int Productid { get; set; }
        public string Prodname { get; set; }
        public decimal? Buyprice { get; set; }
        public decimal? Sellprice { get; set; }

        public virtual ICollection<Inventory7588> Inventory7588 { get; set; }
        public virtual ICollection<Orderline7588> Orderline7588 { get; set; }
        public virtual ICollection<Purchaseorder7588> Purchaseorder7588 { get; set; }
    }
}