using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IAdvertImageRepository : IRepository<AdvertImage>
    {
        Task<AdvertImage> GetAdvertImageByIncludeAsync(int id);
        Task<List<AdvertImage>> GetAdvertImagesByIncludeAsync();
        Task<List<AdvertImage>> GetAdvertImagesByIncludeAsync(Expression<Func<AdvertImage, bool>> expression);
    }
}
