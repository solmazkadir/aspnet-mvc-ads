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
    public class AdvertComment : IEntity, IAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "İlanId")]
        public int? AdvertId { get; set; }
        [Display(Name = "KullanıcıId")]
        public int? UserId { get; set; }
        [Display(Name = "Yorum"), Required]
        public string Comment { get; set; }
        [Display(Name = "Durum")]
        public bool? IsActive { get; set; }
        [ForeignKey(nameof(AdvertId))]
        public virtual Advert Advert { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
