using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class rezervation
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez.")]
        public string description { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(11, ErrorMessage = "En fazla 11 karakter girebilirsiniz.")]
        public string phoneNo { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez.")]
        public System.DateTime rezerveDate { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez.")]
        public int personCount { get; set; }
        public Nullable<bool> showed { get; set; }
    }
}
