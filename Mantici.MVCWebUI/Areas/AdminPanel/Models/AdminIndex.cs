using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Models
{
    public class AdminIndex
    {
        public List<Product> Products { get; set; }
        public List<Branch> Branches { get; set; }
        public List<rezervation> Rezervations { get; set; }
    }
}