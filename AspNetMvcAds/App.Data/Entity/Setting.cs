using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class Setting : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Id")]
        public User UserId { get; set; }
        [Display(Name = "İsim")]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
