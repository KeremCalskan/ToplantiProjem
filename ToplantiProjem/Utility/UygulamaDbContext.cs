using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToplantiProjem.Controllers;
using ToplantiProjem.Models;

namespace ToplantiProjem.Utility
{
    public class UygulamaDbContext : IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext>options): base(options) { }

        public DbSet<Toplanti> Toplantilar { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
