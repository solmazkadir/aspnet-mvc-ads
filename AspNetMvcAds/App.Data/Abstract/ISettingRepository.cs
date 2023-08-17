using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Setting> GetSettingByIncludeAsync(int id);
        Task<List<Setting>> GetSettingsByIncludeAsync();
        Task<List<Setting>> GetSettingsByIncludeAsync(Expression<Func<Setting, bool>> expression);
    }
}
