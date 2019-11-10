using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class BranchPhone
    {
        public int id { get; set; }
        public string BranchPhone1 { get; set; }
        public int BranchID { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
