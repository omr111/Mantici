using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class banner
    {
        public int id { get; set; }
       
        public string bannerPath { get; set; }
        public string altName { get; set; }
        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz.")]
        public string text { get; set; }
    }
}
