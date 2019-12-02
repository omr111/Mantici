using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class review
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        public string comment { get; set; }


        public Nullable<int> userID { get; set; }

        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string visitorName { get; set; }

        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string visitorSurname { get; set; }

        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(70, ErrorMessage = "En fazla 70 karakter girebilirsiniz."), EmailAddress(ErrorMessage = "Ge�erli bir mail adresi giriniz.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz.")]
        public string subject { get; set; }
        public virtual user user { get; set; }
    }
}
