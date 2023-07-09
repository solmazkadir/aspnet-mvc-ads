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
        public Category CategoryId { get; set; }
        public Advert AdvertId { get; set; }
    }
}
