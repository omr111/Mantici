using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class service
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Lütfen bir servis iconu ekleyin.")]
        public string serviceIcon { get; set; }
        [Required(ErrorMessage = "Bir Servis Adý Girmelisiniz."),MaxLength(100,ErrorMessage = "En fazla 100 karakter girebilirsiniz.")]
        public string serviceName { get; set; }
        [MaxLength(250,ErrorMessage = "Bilgi Kýsmý 250 Karakterden Fazla Olamaz !")]
        public string serviceInfo { get; set; }
    }
}
