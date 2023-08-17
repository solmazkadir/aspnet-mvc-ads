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
    public class AdvertCommentRepository : Repository<AdvertComment>, IAdvertCommentRepository
    {
        public AdvertCommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AdvertComment> GetAdvertCommentByIncludeAsync(int id)
        {
            return await _context.AdvertComments.Include(a => a.Advert).Include(a => a.User).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<AdvertComment>> GetAdvertCommentsByIncludeAsync()
        {
            return await _context.AdvertComments.Include(a => a.Advert).Include(a => a.User).ToListAsync();
        }

        public async Task<List<AdvertComment>> GetAdvertCommentsByIncludeAsync(Expression<Func<AdvertComment, bool>> expression)
        {
            return await _context.AdvertComments.Where(expression).Include(a => a.Advert).Include(a => a.User).ToListAsync();
        }
    }
}
