using System;
using System.Collections.Generic;

namespace UCP1_PAW_060.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public DateTime? TanggalTransaksi { get; set; }
        public string KodeBaju { get; set; }
        public string HargaBaju { get; set; }
        public string JumlahBaju { get; set; }
        public string TotalBaju { get; set; }
        public int? IdPenjual { get; set; }
        public int? IdPembeli { get; set; }
    }
}
