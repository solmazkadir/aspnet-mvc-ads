using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class User : IEntity, IAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }
        [MaxLength(200)]
        [Display(Name = "Email"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        [MaxLength(200)]
        [Display(Name = "Password"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR")]
        public string Password { get; set; }
        [MaxLength(20)]
        [Display(Name = "Telefon"), Column(TypeName = "NVARCHAR")]
        public string? Phone { get; set; }
        [MaxLength(200)]
        [Display(Name = "Adres"), Column(TypeName = "NVARCHAR")]
        public string? Address { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        
        public virtual Role? Role { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}
