using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class Branch
    {
        public Branch()
        {
            this.BranchPhones = new List<BranchPhone>();
            this.CompanyInformations = new List<CompanyInformation>();
        }

        public int id { get; set; }
        public string BranchName { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string BranchAdress { get; set; }
        public Nullable<int> BranchPictureID { get; set; }
        public virtual ICollection<BranchPhone> BranchPhones { get; set; }
        public virtual ICollection<CompanyInformation> CompanyInformations { get; set; }
    }
}
