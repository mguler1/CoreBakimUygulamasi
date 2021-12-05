using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreBakimUygulamasi.Data;
using CoreBakimUygulamasi.Models;
using CoreBakimUygulamasi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreBakimUygulamasi.Pages.Makineler
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Makine Makine { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(string userId = null)
        {
            Makine = new Makine();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            Makine.KullaniciId = userId;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            _db.Makine.Add(Makine);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index",new { kullaniciId=Makine.KullaniciId});
        }
    }
}