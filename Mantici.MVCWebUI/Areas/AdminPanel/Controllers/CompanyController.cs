using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class CompanyController : Controller
    {
        // GET: AdminPanel/Company
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult companyEdit(CompanyInformation comInfo)
        {
            return View();
        }
    }
}