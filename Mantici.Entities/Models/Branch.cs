using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class Branch
    {
        public Branch()
        {
            this.BranchPhones = new List<BranchPhone>();
        }

        public int id { get; set; }
        public string BranchName { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string BranchAdress { get; set; }
        public string BranchPicturePath { get; set; }
        public string pictureAlt { get; set; }
        public virtual ICollection<BranchPhone> BranchPhones { get; set; }
    }
}
