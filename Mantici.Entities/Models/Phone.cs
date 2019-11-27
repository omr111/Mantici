using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class Phone
    {
        public int id { get; set; }
        public int CompanyID { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(11, ErrorMessage = "En fazla 11 karakter girebilirsiniz")]
        public string phoneNumber { get; set; }
        public virtual CompanyInformation CompanyInformation { get; set; }
    }
}
