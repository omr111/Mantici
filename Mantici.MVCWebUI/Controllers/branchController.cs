using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Controllers
{
    public class branchController : Controller
    {
        IBranchesApplicationBll _applicationBll=new BranchesApplicationBll(new BranchesApplicationDal());
        IBranchBll _branchBll=new BranchBll(new BranchDal());
        // GET: branch
        public ActionResult Index()
        {
            return View(_branchBll.ListAll());
        }

        public ActionResult branchApplication()
        {
            
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult branchApplication(BranchesApplication application)
        {
            if (ModelState.IsValid)
            {
                bool result = _applicationBll.Add(application);
                if (result)
                {
                    ViewData["applicationInfo"] = "Başvurunuz Gönderildi.";
                    return RedirectToAction("branchApplication");
                }
                else
                {
                    ViewData["applicationInfo"] = "Başvurunuz Gönderilirken Bir Hata Oluştu Lütfen Tekrar Deneyiniz.";
                    return View("branchApplication");
                }
              
            }
            else
            {
                return View("branchApplication");
            }
        }
    }
}