using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models
{
    public class BakimHizmetDetay
    {
        public int Id { get; set; }
        public int BakimHizmetiGenelId { get; set; }
        [ForeignKey("BakimHizmetiGenelId")]
        public virtual BakimHizmetiGenel BakimHizmetiGenel { get; set; }
        [Display(Name ="Bakım")]
        public int BakimTipiId { get; set; }
        [ForeignKey("BakimTipiId")]
        public virtual BakimTipi BakimTipi { get; set; }
        public double BakimFiyati { get; set; }
        public string BakimAdi { get; set; }

    }
}
