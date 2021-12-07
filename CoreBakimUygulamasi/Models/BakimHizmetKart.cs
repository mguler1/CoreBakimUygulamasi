using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models
{
    public class BakimHizmetKart
    {
        public int Id { get; set; }
        public int MakineId { get; set; }
        public int BakımTipiId { get; set; }
        [ForeignKey("MakineId")]
        public virtual  Makine Makine { get; set; }
        [ForeignKey("BakımTipiId")]
        public virtual  BakimTipi BakimTipi { get; set; }
    }
}
