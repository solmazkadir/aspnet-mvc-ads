using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class AdvertImage : IEntity
    {
        public int Id { get; set; }
        public int AdvertId { get; set; }
        [Column(TypeName = "NVARCHAR"), StringLength(200)]
        public string ImagePath { get; set; }
    }
}
