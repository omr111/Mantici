using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class role
    {
        public role()
        {
            this.roleOfUsers = new List<roleOfUser>();
        }

        public int id { get; set; }
        public string roleName { get; set; }
        public virtual ICollection<roleOfUser> roleOfUsers { get; set; }
    }
}
