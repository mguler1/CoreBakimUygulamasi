using CoreBakimUygulamasi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBakimUygulamasi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BakimTipi> BakimTipi { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Makine> Makine { get; set; }
    }
}
