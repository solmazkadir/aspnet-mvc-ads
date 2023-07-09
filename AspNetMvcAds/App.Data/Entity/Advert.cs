using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    public class Advert : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Id")]
        public User UserId { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

    }
}
