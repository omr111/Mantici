using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class BranchesApplication
    {
        public int id { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(70, ErrorMessage = "En fazla 70 karakter girebilirsiniz")]
        public string nameSurname { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(70, ErrorMessage = "En fazla 70 karakter girebilirsiniz"),EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string email { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(11, ErrorMessage = "En fazla 70 karakter girebilirsiniz"),Phone(ErrorMessage = ="Geçerli bir telefon numarasý giriniz")]
        public string phoneNumber { get; set; }
        [Required("Bu alan boþ geçilemez!"),MaxLength(250,ErrorMessage = "En fazla 250 karakter girebilirsiniz")]
        public string Address { get; set; }
        [Required("Bu alan boþ geçilemez!"),MaxLength(500,ErrorMessage = "En fazla 500 karakter girebilirsiniz")]
        public string message { get; set; }
    }
}
