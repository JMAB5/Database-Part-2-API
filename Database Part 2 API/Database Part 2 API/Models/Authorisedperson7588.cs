using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Authorisedperson7588
    {
        public Authorisedperson7588()
        {
            Clientauthorisedaccounts7588 = new HashSet<Clientauthorisedaccounts7588>();
            Order7588 = new HashSet<Order7588>();
        }

        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Accountid { get; set; }

        public virtual Clientaccount7588 Account { get; set; }
        public virtual ICollection<Clientauthorisedaccounts7588> Clientauthorisedaccounts7588 { get; set; }
        public virtual ICollection<Order7588> Order7588 { get; set; }
    }
}