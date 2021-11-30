using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }//toplam kullanıcı
        public int ItemsPerPage { get; set; }//sayfa başı kullanıcı sayısı
        public int CurrentPage { get; set; }//güncel sayfa
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);//toplam sayfa sayısı

        public string UrlParam { get; set; }
    }
}
