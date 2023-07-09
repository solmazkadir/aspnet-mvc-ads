using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR"), StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Açıklama"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR"), StringLength(200)]
        public string Description { get; set; }
    }
}
