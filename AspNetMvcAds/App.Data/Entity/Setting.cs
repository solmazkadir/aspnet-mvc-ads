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
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Id")]
        public int UserId { get; set; }
        [Display(Name = "İsim"), Column(TypeName = "NVARCHAR"), StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "Değer"), Column(TypeName = "NVARCHAR"), StringLength(200)]
        public string Value { get; set; }
    }
}
