using App.Data.Abstract;
using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Concrete
{
    public class AdvertRepository : Repository<Advert>, IAdvertRepository
    {
        public AdvertRepository(AppDbContext context, DbSet<Advert> dbSet) : base(context, dbSet)
        {
        }

        public async Task<Advert> GetAdvertByIncludeAsync(int id)
        {
            return await _context.Adverts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Advert>> GetAdvertsByIncludeAsync()
        {
            return await _context.Adverts.ToListAsync();
        }

        public async Task<List<Advert>> GetAdvertsByIncludeAsync(Expression<Func<Advert, bool>> expression)
        {
            return await _context.Adverts.Where(expression).ToListAsync();
        }
    }
}
