using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class CompanyInformation
    {
        public CompanyInformation()
        {
            this.Phones = new List<Phone>();
        }

        public int id { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        public string companyName { get; set; }
        [Required("Bu alan boþ geçilemez!")]
        public string companyAbout { get; set; }
        [Required("Bu alan boþ geçilemez!")]
        public string companyLogo { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(70, ErrorMessage = "En fazla 70 karakter girebilirsiniz"),EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string email { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz")]
        public string companyAddress { get; set; }
        [Required("Bu alan boþ geçilemez!")]
        public string companyPicturePath { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz")]
        public string videoPath { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz")]
        public string videoText { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
