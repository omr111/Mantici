using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Models
{
    public class usersAndRoles
    {
        public List<user> Users { get; set; }
        public List<role> Roles { get; set; }
    }
}