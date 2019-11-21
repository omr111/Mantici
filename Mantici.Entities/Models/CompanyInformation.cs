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
        public string email { get; set; }
        public string companyAddress { get; set; }
        public string companyPicturePath { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
