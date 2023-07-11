using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class Role : IEntity
    {
        [Required]
        [MinLength(1)]
        [Column(TypeName ="nvarchar")]
        public string? Name { get; set; }
    }
}
