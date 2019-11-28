using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class role
    {
        public role()
        {
            this.roleOfUsers = new List<roleOfUser>();
        }

        public int id { get; set; }
        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(10, ErrorMessage = "En fazla 10 karakter girebilirsiniz.")]
        public string roleName { get; set; }
        public virtual ICollection<roleOfUser> roleOfUsers { get; set; }
    }
}
