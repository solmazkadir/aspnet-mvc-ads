using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR"), StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Email"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "VARCHAR"), StringLength(250)]
        public string Email { get; set; }
        [Display(Name = "Password"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR"), StringLength(100)]
        public string Password { get; set; }
        [Display(Name = "Telefon"), Column(TypeName = "NVARCHAR"), StringLength(20)]
        public string? Phone { get; set; }
        [Display(Name = "Adres"), Column(TypeName = "NVARCHAR"), StringLength(200)]
        public string? Address { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; }


        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role? Role { get; set; }
    }
}
