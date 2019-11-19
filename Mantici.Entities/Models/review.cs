using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class review
    {
        public int id { get; set; }
        public string comment { get; set; }
        public Nullable<int> userID { get; set; }
        public string visitorName { get; set; }
        public string visitorSurname { get; set; }
        public virtual user user { get; set; }
    }
}
