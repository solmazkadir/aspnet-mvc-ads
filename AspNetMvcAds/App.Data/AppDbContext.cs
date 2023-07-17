using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace App.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertComment> AdvertComments { get; set; }
        public DbSet<AdvertImage> AdvertImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }



    }
}
