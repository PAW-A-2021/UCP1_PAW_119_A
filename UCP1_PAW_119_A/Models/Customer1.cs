using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_119_A.Models
{
    public partial class Customer1
    {
        public Customer1()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdCustomer { get; set; }
        public string Nama { get; set; }
        public string NoTelp { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
