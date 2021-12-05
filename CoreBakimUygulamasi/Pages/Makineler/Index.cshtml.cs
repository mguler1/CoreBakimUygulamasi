using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreBakimUygulamasi.Data;
using CoreBakimUygulamasi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreBakimUygulamasi.Pages.Makineler
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public KullanýcýMakineViewModel kullanýcýMakineViewModel { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(string KullaniciId = null)
        {
            if (KullaniciId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                KullaniciId = claim.Value;
            }
            kullanýcýMakineViewModel = new KullanýcýMakineViewModel()
            {
                Makineler = await _db.Makine.Where(x => x.KullaniciId == KullaniciId).ToListAsync(),
                UserObj = await _db.ApplicationUser.FirstOrDefaultAsync(a => a.Id == KullaniciId)
            };
                
            return Page();
        }

    }
}

