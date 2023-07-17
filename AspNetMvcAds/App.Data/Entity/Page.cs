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
    public class Page : IEntity, IAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(200)]
        [Display(Name = "Başlık"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR")]
        public string Title { get; set; }
        [Display(Name = "İçerik"), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        [Column(TypeName = "text")]
        public string Content { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
