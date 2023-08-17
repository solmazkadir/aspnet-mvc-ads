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
    public class UserRoleRepository : Repository<User>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByIncludeAsync(int id)
        {
            return await _context.Users.Include(p => p.Role).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<User>> GetUsersByIncludeAsync()
        {
            return await _context.Users.Include(p => p.Role).ToListAsync();
        }

        public async Task<List<User>> GetUsersByIncludeAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Where(expression).Include(p => p.Role).ToListAsync();
        }
    }
}
