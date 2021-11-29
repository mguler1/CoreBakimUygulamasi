using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string NameSurname { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
    }
}
