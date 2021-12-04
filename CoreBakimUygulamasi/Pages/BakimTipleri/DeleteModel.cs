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
using Microsoft.EntityFrameworkCore;

namespace CoreBakimUygulamasi.Pages.BakimTipleri
{
    [Authorize(Roles = StaticRoller.AdminUser)]

    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
            public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public BakimTipi BakimTipi { get; set; }
        public async Task<IActionResult>OnGetAsync(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            BakimTipi = await _db.BakimTipi.FirstOrDefaultAsync(a => a.Id == id);
                if (BakimTipi==null)
            {
                return NotFound();

            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(BakimTipi x)
        {
            if (x==null)
            {
                return NotFound();
            }
            _db.Remove(x);
            await _db.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
