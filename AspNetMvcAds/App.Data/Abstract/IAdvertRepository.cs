using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IAdvertRepository : IRepository<Advert>
    {
        Task<Advert> GetAdvertByIncludeAsync(int id); 
        Task<List<Advert>> GetAdvertsByIncludeAsync(); 
        Task<List<Advert>> GetAdvertsByIncludeAsync(Expression<Func<Advert, bool>> expression);
    }
}
