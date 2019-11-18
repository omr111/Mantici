using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class roleOfUser
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int roleID { get; set; }
        public virtual role role { get; set; }
        public virtual user user { get; set; }
    }
}
