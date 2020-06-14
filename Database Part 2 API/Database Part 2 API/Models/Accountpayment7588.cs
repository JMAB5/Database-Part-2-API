
using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Accountpayment7588
    {
        public int Accountid { get; set; }
        public DateTime Datetimereceived { get; set; }
        public decimal Amount { get; set; }

        public virtual Clientaccount7588 Account { get; set; }
    }
}