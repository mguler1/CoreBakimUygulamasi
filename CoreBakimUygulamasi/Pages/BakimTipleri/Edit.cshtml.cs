using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreBakimUygulamasi.Data;
using CoreBakimUygulamasi.Models;

namespace CoreBakimUygulamasi.Pages.BakimTipleri
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public BakimTipi BakimTipi { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BakimTipi = await _db.BakimTipi.FirstOrDefaultAsync(m => m.Id == id);

            if (BakimTipi == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var BakimFromDb = await _db.BakimTipi.FirstOrDefaultAsync(x => x.Id == BakimTipi.Id);
            BakimFromDb.BakimAdi = BakimTipi.BakimAdi;
            BakimFromDb.BakimFiyati = BakimTipi.BakimFiyati;
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool BakimTipiExists(int id)
        {
            return _db.BakimTipi.Any(e => e.Id == id);
        }
    }
}
