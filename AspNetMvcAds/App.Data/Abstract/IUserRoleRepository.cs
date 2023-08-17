using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IUserRoleRepository : IRepository<User>
    {
        Task<User> GetUserByIncludeAsync(int id);
        Task<List<User>> GetUsersByIncludeAsync();
        Task<List<User>> GetUsersByIncludeAsync(Expression<Func<User, bool>> expression);
    }
}
