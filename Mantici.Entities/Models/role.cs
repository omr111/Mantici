using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class role
    {
        public int id { get; set; }
        public string role1 { get; set; }
        public virtual roleOfUser roleOfUser { get; set; }
    }
}
