using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBakimUygulamasi.Data;
using CoreBakimUygulamasi.Models;
using CoreBakimUygulamasi.Models.ViewModel;
using CoreBakimUygulamasi.Utility;
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
        public UserListViewModel  UserListViewModel { get; set; }
        public async Task <IActionResult> OnGet(int productPage=1)
        {
            UserListViewModel = new UserListViewModel()
            {
             ApplicationUsers= await _db.ApplicationUser.ToListAsync()
            };
            StringBuilder param = new StringBuilder();
            param.Append("/Kullanicilar?productPage=:");

            var sayi = UserListViewModel.ApplicationUsers.Count;
            UserListViewModel.pagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = StaticRoller.UserPaginationSize,
                TotalItems = sayi,
                UrlParam = param.ToString()
            };
            UserListViewModel.ApplicationUsers = UserListViewModel.ApplicationUsers.OrderBy(x => x.Email).Skip((productPage - 1) * StaticRoller.UserPaginationSize).Take(StaticRoller.UserPaginationSize).ToList();
            return Page();
        }
    }
}
