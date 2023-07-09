using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Name { get; set; }
        [Display(Name = "Açıklama"), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Description { get; set; }
    }
}
