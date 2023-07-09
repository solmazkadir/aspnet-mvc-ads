using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Name { get; set; }
        [Display(Name = "Email"), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Email { get; set; }
        [Display(Name = "Password"), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Password { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; }

    }
}
