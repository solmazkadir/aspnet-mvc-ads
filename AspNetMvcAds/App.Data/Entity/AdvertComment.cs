using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entity
{
    internal class AdvertComment
    {
        public int Id { get; set; }
        [Display(Name = "İlanId")]
        public int AdvertId { get; set; }
        [Display(Name = "KullanıcıId")]
        public int UserId { get; set; }
        [Display(Name = "Yorum")]
        public string Comment { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
    }
}
