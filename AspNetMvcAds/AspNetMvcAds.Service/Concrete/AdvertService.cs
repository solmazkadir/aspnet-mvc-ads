using App.Data;
using App.Data.Concrete;
using App.Data.Entity;
using AspNetMvcAds.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcAds.Service.Concrete
{
    public class AdvertService : AdvertRepository, IAdvertService
    {
        public AdvertService(AppDbContext context, DbSet<Advert> dbSet) : base(context, dbSet)
        {
        }
    }
}
