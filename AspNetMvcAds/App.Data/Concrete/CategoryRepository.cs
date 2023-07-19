using App.Data.Abstract;
using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Concrete
{
    public class CategoryRepository : Repository<CategoryAdvert>, ICategoryAdvertRepository
    {
        public CategoryRepository(AppDbContext context, DbSet<CategoryAdvert> dbSet) : base(context, dbSet)
        {
        }

        public async Task<CategoryAdvert> GetAdvertByIncludeAsync(int id)
        {
            return await _dbSet.Where(c => c.Id == id).AsNoTracking().Include(c =>c.adverts).FirstOrDefaultAsync();
        }


        public async Task<CategoryAdvert> GetCategoryByIncludeAsync(int id)
        {
            return await _dbSet.Where(c => c.Id == id).AsNoTracking().Include(c => c.Category).FirstOrDefaultAsync();
        }
    }
}
