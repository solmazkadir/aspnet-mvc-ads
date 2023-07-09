using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class CategoryAdvert : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AdvertId { get; set; }
    }
}
