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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? AdvertId { get; set; }
        [MaxLength(200)]
        [Column(TypeName = "NVARCHAR")]
        public string? ImagePath { get; set; }
        [ForeignKey(nameof(AdvertId))]
        public virtual Advert? adverts { get; set; }
    }
}
