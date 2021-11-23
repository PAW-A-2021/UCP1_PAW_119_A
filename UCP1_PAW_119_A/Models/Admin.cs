using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_119_A.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdAdmin { get; set; }
        public string Nama { get; set; }
        public string NoTelp { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
