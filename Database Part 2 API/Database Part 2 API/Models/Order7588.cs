using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Order7588
    {
        public Order7588()
        {
            Orderline7588 = new HashSet<Orderline7588>();
        }

        public int Orderid { get; set; }
        public string Shippingaddress { get; set; }
        public DateTime Datetimecreated { get; set; }
        public DateTime? Datetimedispatched { get; set; }
        public decimal Total { get; set; }
        public int Userid { get; set; }

        public virtual Authorisedperson7588 User { get; set; }
        public virtual ICollection<Orderline7588> Orderline7588 { get; set; }
    }
}