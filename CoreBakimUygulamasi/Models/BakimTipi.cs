using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models
{
    public class BakimTipi
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu Alan Zorunludur.")]
        public string BakimAdi { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunludur.")]
        public double BakimFiyati { get; set; }
    }
}
