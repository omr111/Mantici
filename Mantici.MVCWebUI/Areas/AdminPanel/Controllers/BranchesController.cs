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
        IBranchPhoneBll _branchPhone=new BranchPhoneBll(new BranchPhoneDal());
        // GET: AdminPanel/Branches
        public ActionResult Index()
        {
           
            return View( _branchBll.ListAll());
        }

        public ActionResult branchAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult branchAdd(Branch branch, string[] BranchPhone1, HttpPostedFileBase file)
        {
            
            branch.BranchPictureID = pictureController.pictureAddInt(file, HttpContext);
            _branchBll.Add(branch);
            for (int i = 0; i < BranchPhone1.Length; i++)
            {
                if (BranchPhone1[i] != "")
                {
                    BranchPhone branchPhone = new BranchPhone();
                    branchPhone.BranchID = branch.id;
                    branchPhone.BranchPhone1 = BranchPhone1[i];
                    _branchPhone.Add(branchPhone);
                }
            }
            return RedirectToAction("Index","Branches",new{area="AdminPanel"});
        }
    }
}