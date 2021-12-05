using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBakimUygulamasi.Data;
using CoreBakimUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreBakimUygulamasi.Pages.Makineler
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Makine Makine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Makine = await _db.Makine.Include(x=>x.ApplicationUser).FirstOrDefaultAsync(m => m.MakineId == id);

            if (Makine == null)
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

            _db.Attach(Makine).State = EntityState.Modified;
            await _db.SaveChangesAsync();
           

            return RedirectToPage("./Index",new { KullaniciId = Makine.KullaniciId });
        }

        
    }
}

    