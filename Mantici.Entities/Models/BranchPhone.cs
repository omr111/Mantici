using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class BranchPhone
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(11, ErrorMessage = "En fazla 11 karakter girebilirsiniz.")]
        public string BranchPhone1 { get; set; }
        public int BranchID { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
