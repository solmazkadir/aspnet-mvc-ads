﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class CategoryAdvert : IEntity, IAuditEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? AdvertId { get; set; }

        public virtual Advert adverts { get; set; }
        public virtual Category Category { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
