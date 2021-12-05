using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBakimUygulamasi.Data;
using CoreBakimUygulamasi.Models;
using CoreBakimUygulamasi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreBakimUygulamasi.Pages.BakimTipleri
{
   // [Authorize(Roles =StaticRoller.AdminUser)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public BakimTipi BakimTipi { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(BakimTipi BakimTipi)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.BakimTipi.Add(BakimTipi);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}