using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class Phone
    {
        public int id { get; set; }
        public int CompanyID { get; set; }
        public string phone1 { get; set; }
        public virtual CompanyInformation CompanyInformation { get; set; }
    }
}
