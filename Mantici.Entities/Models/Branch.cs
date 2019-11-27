using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class Branch
    {
        public Branch()
        {
            this.BranchPhones = new List<BranchPhone>();
        }

        public int id { get; set; }
        [Required("Bu alan boþ geçilemez!"),MaxLength(70,ErrorMessage = "En fazla 70 karakter girebilirsiniz")]
        public string BranchName { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz")]
        public string area { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz")]
        public string city { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(70, ErrorMessage = "En fazla 70 karakter girebilirsiniz"),EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz.")]
        public string email { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz")]
        public string BranchAdress { get; set; }
        [Required("Bu alan boþ geçilemez!")]
        public string BranchPicturePath { get; set; }
        public string pictureAlt { get; set; }
        public virtual ICollection<BranchPhone> BranchPhones { get; set; }
    }
}
