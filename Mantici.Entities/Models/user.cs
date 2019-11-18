using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class user
    {
        public user()
        {
            this.roleOfUsers = new List<roleOfUser>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string nick { get; set; }
        public string email { get; set; }
        public string userPicturePath { get; set; }
        public bool isBlock { get; set; }
        public virtual ICollection<roleOfUser> roleOfUsers { get; set; }
    }
}
