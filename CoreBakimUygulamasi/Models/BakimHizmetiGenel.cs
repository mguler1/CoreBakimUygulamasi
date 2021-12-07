using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models
{
    public class BakimHizmetiGenel
    {
        public int Id { get; set; }
        public double MakineSayacSaat { get; set; }
        [Required]
        public double ToplamFiyat { get; set; }
        public string Detaylar { get; set; }
        [Required]
            [DisplayFormat(DataFormatString ="{0:dd MMM Y}")]
        public DateTime EklemeTarihi { get; set; }
        public int MakineId { get; set; }
        [ForeignKey("MakineId")]
        public virtual Makine Makine { get; set; }
    }
}
