using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Data
{
	public class AppDbContext : DbContext
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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=AspNetMvcAds; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().Property(a => a.Name).IsRequired().HasMaxLength(50); 
            modelBuilder.Entity<User>().Property(a => a.UserName).HasColumnType("varchar(50)").HasMaxLength(50);
            modelBuilder.Entity<User>().Property(a => a.Password).IsRequired().HasColumnType("nvarchar(100)").HasMaxLength(100);
            modelBuilder.Entity<User>().Property(a => a.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(a => a.Phone).HasMaxLength(20);
            

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           

            base.OnModelCreating(modelBuilder);
        }



    }
}
