using App.Data;
using App.Data.Concrete;
using App.Service.Abstract;

namespace App.Service.Concrete
{
    public class AdvertCommentService : AdvertCommentRepository, IAdvertCommentService
    {
        public AdvertCommentService(AppDbContext context) : base(context)
        {
        }
    }
}
