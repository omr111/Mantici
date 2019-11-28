using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class user
    {
        public user()
        {
            this.reviews = new List<review>();
            this.roleOfUsers = new List<roleOfUser>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(10, ErrorMessage = "En fazla 10 karakter girebilirsiniz.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string personelName { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz."),EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz.")]
        public string password { get; set; }

        public string userPicturePath { get; set; }
        public bool isBlock { get; set; }
        public virtual ICollection<review> reviews { get; set; }
        public virtual ICollection<roleOfUser> roleOfUsers { get; set; }
    }
}
