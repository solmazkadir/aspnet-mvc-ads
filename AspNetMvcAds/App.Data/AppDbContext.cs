using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Data
{
    public class AppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertComment> AdvertComments { get; set; }
        public DbSet<AdvertImage> AdvertImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Setting> Settings { get; set; }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=AspNetMvcAds; Trusted_Connection=True");
            
        //    base.OnConfiguring(optionsBuilder);
        //}





        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(new User
        //    {
        //        Id = 1,
        //        Email = "info@Ads.com",
        //        Password = "123",
        //        UserName = "Admin",
        //        IsActive = true,
        //        IsAdmin = true,
        //        Name = "Admin",
        //        UserGuid = Guid.NewGuid(), 
        //    });


        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
