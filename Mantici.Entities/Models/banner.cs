using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class banner
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Lütfen bir resim seçiniz.")]
        public string bannerPath { get; set; }
        public string altName { get; set; }
        [Required(ErrorMessage = "Lütfen yazý alanýný boþ býrakmayýn!"),MaxLength(200,ErrorMessage = "En fazla 200 karakter girebilirsiniz!")]
        public string text { get; set; }
    }
}
