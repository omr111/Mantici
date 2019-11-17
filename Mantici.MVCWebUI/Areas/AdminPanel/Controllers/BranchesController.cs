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
    public class BranchesController : Controller
    {
        IBranchBll _branchBll=new BranchBll(new BranchDal());
        // GET: AdminPanel/Branches
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult branchAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult branchAdd(Branch branch, List<BranchPhone> phones, HttpPostedFileBase file)
        {
            branch.BranchPictureID = pictureController.pictureAddInt(file, HttpContext);
            _branchBll.Add(branch);
            return RedirectToAction("Index");
        }
    }
}