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

        public async Task<Advert> GetAdvertByIncludeAsync(int id)//byidasync
        {
            return await _context.Adverts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Advert>> GetAdvertsByIncludeAsync()
        {
            return await _context.Adverts.ToListAsync();
        }

        public async Task<List<Advert>> GetAdvertsByIncludeAsync(Expression<Func<Advert, bool>> expression) //isimleri düzenle
        {
            return await _context.Adverts.Where(expression).ToListAsync();
        }

        public async Task<List<Advert>> GetAdvertsByContentAndLocationAsync(string searchKey, string? location = null)
        {
            IQueryable<Advert> query = _context.Adverts;

            query = query.Where(p => p.Title.Contains(searchKey) || p.Description.Contains(searchKey));
            if (location != null)
            {
                query = query.Where(p => p.Location.Contains(location));
            }

            return await query.ToListAsync();
        }
    }
}
