using App.Data.Entity;
using System.Linq.Expressions;

namespace App.Data.Abstract
{
    public interface IAdvertCommentRepository : IRepository<AdvertComment>
    {
        Task<AdvertComment> GetAdvertCommentByIncludeAsync(int id); 
        Task<List<AdvertComment>> GetAdvertCommentsByIncludeAsync(); 
        Task<List<AdvertComment>> GetAdvertCommentsByIncludeAsync(Expression<Func<AdvertComment, bool>> expression);
    }
}
