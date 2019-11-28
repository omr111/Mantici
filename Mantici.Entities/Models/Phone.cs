using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class Phone
    {
        public int id { get; set; }
        public int CompanyID { get; set; }
      
        public string phoneNumber { get; set; }
        public virtual CompanyInformation CompanyInformation { get; set; }
    }
}
