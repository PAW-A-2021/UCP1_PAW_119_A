using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_119_A.Models
{
    public partial class Outfit
    {
        public Outfit()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdOutfit { get; set; }
        public string NamaOutfit { get; set; }
        public string Perusahaan { get; set; }
        public int? Harga { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
