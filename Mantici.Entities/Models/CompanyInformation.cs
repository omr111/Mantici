using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class CompanyInformation
    {
        public CompanyInformation()
        {
            this.Phones = new List<Phone>();
        }

        public int id { get; set; }
        public string companyName { get; set; }
        public string companyAbout { get; set; }
        public string companyLogo { get; set; }
        public string companyAddress { get; set; }
        public int BranchID { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
