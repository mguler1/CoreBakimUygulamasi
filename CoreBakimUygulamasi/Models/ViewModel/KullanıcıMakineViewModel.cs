using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models.ViewModel
{
    public class KullanıcıMakineViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<Makine>Makineler { get; set; }
    }
}
