using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class rezervation
    {
        public int id { get; set; }
        public string CustomerName { get; set; }
        public string surname { get; set; }
        public string description { get; set; }
        public System.DateTime rezerveDate { get; set; }
        public Nullable<int> personCount { get; set; }
        public bool showed { get; set; }
    }
}
