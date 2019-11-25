using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class BranchesApplication
    {
        public int id { get; set; }
        public string nameSurname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string Address { get; set; }
        public string message { get; set; }
    }
}
