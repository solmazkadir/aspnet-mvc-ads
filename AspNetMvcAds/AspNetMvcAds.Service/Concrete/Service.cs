using App.Data;
using App.Data.Concrete;
using App.Data.Entity;
using AspNetMvcAds.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvcAds.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(AppDbContext context, DbSet<T> dbSet) : base(context, dbSet)
        {
        }
    }
}
