using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models.ViewModel
{
    public class MakineBakımHizmetiViewModel
    {
        public Makine Makine { get; set; }
        public BakimHizmetiGenel BakimHizmetiGenel { get; set; }
        public BakimHizmetDetay BakimHizmetDetay { get; set; }
        public List<BakimTipi> BakımTipleriListesi { get; set; }
        public List<BakimHizmetKart> BakimHizmetKartListesi { get; set; }
    }
}