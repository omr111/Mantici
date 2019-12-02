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
        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string companyName { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(500, ErrorMessage = "En fazla 500 karakter girebilirsiniz. ")]
        public string companyAbout { get; set; }


        public string companyLogo { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(70, ErrorMessage = "En fazla 70 karakter girebilirsiniz."), EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz.")]
        public string companyAddress { get; set; }

        public string companyPicturePath { get; set; }
        [Required(ErrorMessage = "Bu alan boþ geçilemez.")]
        public string videoPath { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz.")]
        public string videoText { get; set; }
 

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz.")]
        public string facebookUrl { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz.")]
        public string youtubeUrl { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz.")]
        public string InstagramUrl { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz.")]
        public string twitterUrl { get; set; }

        [MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string emailPassword { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
