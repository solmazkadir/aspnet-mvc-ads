using App.Data;
using App.Data.Abstract;
using App.Data.Concrete;
using App.Data.Entity;
using AspNetMvcAds.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcAds.Service.Concrete
{
    public class CategoryAdvertService : CategoryRepository, ICategoryAdvertService
    {
        public CategoryAdvertService(AppDbContext context, DbSet<CategoryAdvert> dbSet) : base(context, dbSet)
        {
        }
    }
}
