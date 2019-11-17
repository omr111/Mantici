using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class roleOfUser
    {
        public roleOfUser()
        {
            this.roles = new List<role>();
        }

        public int id { get; set; }
        public int userID { get; set; }
        public int roleID { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<role> roles { get; set; }
    }
}
