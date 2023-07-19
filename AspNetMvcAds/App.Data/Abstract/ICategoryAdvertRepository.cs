using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface ICategoryAdvertRepository : IRepository<CategoryAdvert>
    {
        Task<CategoryAdvert> GetCategoryByIncludeAsync(int id);
        Task<CategoryAdvert> GetAdvertByIncludeAsync(int id);
    }
}
