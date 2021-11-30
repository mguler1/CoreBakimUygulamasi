using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models.ViewModel
{
    public class UserListViewModel
    {
        public List<ApplicationUser>ApplicationUsers { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}
