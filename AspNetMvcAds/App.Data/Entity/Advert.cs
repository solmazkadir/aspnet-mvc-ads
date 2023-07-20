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
    public class Advert : IEntity, IAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Display(Name = "Kullanıcı Id")]
        public int? UserId { get; set; }

        [MaxLength(200)]
        [Display(Name = "Başlık"), Column(TypeName = "NVARCHAR"),Required]
        public string Title { get; set; }

        [Display(Name = "Açıklama"), Required]
        public string Description { get; set; }

        public string Location { get; set; } = string.Empty; //düzenle

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }


    }
}
