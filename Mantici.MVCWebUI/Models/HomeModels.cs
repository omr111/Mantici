using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Models
{
    public class HomeModels
    {
        public List<banner> Banners { get; set; }
        public List<service> Services { get; set; }
        public List<Product> menuSliders { get; set; }
        public List<Product> menuList { get; set; }
        public CompanyInformation company { get; set; }
      
        public List<review> Reviews { get; set; }



    }
}