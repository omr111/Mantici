using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class service
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez.")]
        public string serviceIcon { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz.")]
        public string serviceName { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz.")]
        public string serviceInfo { get; set; }
    }
}
