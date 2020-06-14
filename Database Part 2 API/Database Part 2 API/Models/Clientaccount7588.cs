using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Clientaccount7588
    {
        public Clientaccount7588()
        {
            Accountpayment7588 = new HashSet<Accountpayment7588>();
            Authorisedperson7588 = new HashSet<Authorisedperson7588>();
            Clientauthorisedaccounts7588 = new HashSet<Clientauthorisedaccounts7588>();
        }

        public int Accountid { get; set; }
        public string Acctname { get; set; }
        public decimal Balance { get; set; }
        public decimal Creditlimit { get; set; }

        public virtual ICollection<Accountpayment7588> Accountpayment7588 { get; set; }
        public virtual ICollection<Authorisedperson7588> Authorisedperson7588 { get; set; }
        public virtual ICollection<Clientauthorisedaccounts7588> Clientauthorisedaccounts7588 { get; set; }
    }
}