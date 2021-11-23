using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_119_A.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdOutfit { get; set; }
        public string Total { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Customer1 IdCustomerNavigation { get; set; }
        public virtual Outfit IdOutfitNavigation { get; set; }
    }
}
