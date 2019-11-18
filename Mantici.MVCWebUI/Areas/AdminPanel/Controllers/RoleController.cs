using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class RoleController : Controller
    {
        IroleBll _roleBll=new roleBll(new roleDal());
        // GET: AdminPanel/Role
        public ActionResult Index()
        {
            return View();
        }

        
       
    }
}