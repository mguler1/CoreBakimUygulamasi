using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBakimUygulamasi.Data;
using CoreBakimUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreBakimUygulamasi.Pages.Kullanicilar
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<ApplicationUser> ApplicationUsersList { get; set; }
        public async Task <IActionResult> OnGet()
        {
            ApplicationUsersList = await _db.ApplicationUser.ToListAsync();
            return Page();
        }
    }
}
