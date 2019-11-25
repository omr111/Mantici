using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Models
{
    public class productUpdateModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}