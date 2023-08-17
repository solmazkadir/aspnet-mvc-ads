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
    public class AdvertImageRepository : Repository<AdvertImage>, IAdvertImageRepository
    {
        public AdvertImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AdvertImage> GetAdvertImageByIncludeAsync(int id)
        {
            return await _context.AdvertImages.Include(p => p.adverts).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<AdvertImage>> GetAdvertImagesByIncludeAsync()
        {
            return await _context.AdvertImages.Include(p => p.adverts).ToListAsync();
        }

        public async Task<List<AdvertImage>> GetAdvertImagesByIncludeAsync(Expression<Func<AdvertImage, bool>> expression)
        {
            return await _context.AdvertImages.Where(expression).Include(p => p.adverts).ToListAsync();
        }
    }
}
