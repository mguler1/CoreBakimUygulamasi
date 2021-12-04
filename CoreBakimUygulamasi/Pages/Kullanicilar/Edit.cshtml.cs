using CoreBakimUygulamasi.Data;
using CoreBakimUygulamasi.Models;
using CoreBakimUygulamasi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBakimUygulamasi.Pages.Kullanicilar
{
    [Authorize(Roles = StaticRoller.AdminUser)]

    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db=db;
        }
        [BindProperty]
        public ApplicationUser applicationUser { get; set; }
        public async Task<IActionResult> OnGetAsync (string? id)
        {
            if (id.Trim().Length==0)
            {
                return NotFound();
            }
            applicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(x => x.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult>OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var kullan�c� = await _db.ApplicationUser.SingleOrDefaultAsync(x => x.Id == applicationUser.Id);
            if (kullan�c�==null)
            {
                return NotFound();
            }
            kullan�c�.NameSurname = applicationUser.NameSurname;
            kullan�c�.UserName = applicationUser.UserName;
            kullan�c�.Adress = applicationUser.Adress;
            kullan�c�.City = applicationUser.City;
            kullan�c�.PhoneNumber = applicationUser.PhoneNumber;
            await _db.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
