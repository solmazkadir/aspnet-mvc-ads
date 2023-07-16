using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class AdvertComment : IEntity, IAuditEntity
    {
        public int Id { get; set; }
        [Display(Name = "İlanId")]
        public int? AdvertId { get; set; }
        [Display(Name = "KullanıcıId")]
        public int? UserId { get; set; }
        [Display(Name = "Yorum")]
        public string Comment { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }

        public virtual Advert Advert { get; set; }
        public virtual User User { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
