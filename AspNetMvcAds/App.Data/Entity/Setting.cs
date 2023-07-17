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
    public class Setting : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Id")]
        public int? UserId { get; set; }
        [MaxLength(200)]
        [Display(Name = "İsim"), Column(TypeName = "NVARCHAR"),Required]
        public string Name { get; set; }
        [MaxLength(200)]
        [Display(Name = "Değer"), Column(TypeName = "NVARCHAR"),Required]
        public string Value { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
    }
}
