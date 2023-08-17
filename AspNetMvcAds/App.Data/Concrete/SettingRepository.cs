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
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        public SettingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Setting> GetSettingByIncludeAsync(int id)
        {
            return await _context.Settings.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Setting>> GetSettingsByIncludeAsync()
        {
            return await _context.Settings.Include(p => p.User).ToListAsync();
        }

        public async Task<List<Setting>> GetSettingsByIncludeAsync(Expression<Func<Setting, bool>> expression)
        {
            return await _context.Settings.Where(expression).Include(p => p.User).ToListAsync();
        }
    }
}
