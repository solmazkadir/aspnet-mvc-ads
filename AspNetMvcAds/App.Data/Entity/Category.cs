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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }
        [MaxLength(200)]
        [Display(Name = "Açıklama"), Required(ErrorMessage = "{0} Alanı Gereklidir!"), Column(TypeName = "NVARCHAR")]
        public string Description { get; set; }
    }
}
