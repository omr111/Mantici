using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class BranchesApplication
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(70, ErrorMessage = "En fazla 70 karakter girebilirsiniz.")]
        public string nameSurname { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz."),EmailAddress(ErrorMessage ="Ge�erli bir mail adresi giriniz.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(11, ErrorMessage = "En fazla 11 karakter girebilirsiniz.")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez."), MaxLength(500, ErrorMessage = "En fazla 500 karakter girebilirsiniz.")]
        public string message { get; set; }
    }
}
