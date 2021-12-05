using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models
{
    public class Makine
    {[Key]
        public int MakineId { get; set; }
        [Required]
        public string MakineSeriNo { get; set; }
        [Required]
        public string MakineMarka { get; set; }
        [Required]
        public string MakineModel { get; set; }
        public string MakineTipi { get; set; }
        [Required]
        public int MakineUretimTarihi { get; set; }
        [Required]
        public double MakineSaatSayaci{ get; set; }
        public string MakineAciklama{ get; set; }

        public string KullaniciId { get; set; }
        [ForeignKey("KullaniciId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
