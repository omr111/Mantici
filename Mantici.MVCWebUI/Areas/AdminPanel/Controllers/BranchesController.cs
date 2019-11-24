using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;
using Mantici.Entities.Models.Mapping;

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
            
            branch.BranchPicturePath = pictureController.pictureAddForBranch(file, HttpContext);
            if (file.FileName.Length > 50)
            {
                branch.pictureAlt = file.FileName.Substring(0, 49);
            }
            else
            {
                branch.pictureAlt = file.FileName;
            }
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

        [HttpPost]
        public int branchDelete(int id)
        {

            Branch branch = _branchBll.GetOne(id);

            if (branch != null)
            {
               List<BranchPhone> phones= _branchPhone.ListAllOftheUser(branch.id);
               if (phones.Count>0)
               {
                   foreach (var phone in phones)
                   {
                       _branchPhone.Delete(phone.id);
                   }
               }
                
                
                if (System.IO.File.Exists(Server.MapPath(branch.BranchPicturePath)))
                {
                    System.IO.File.Delete(Server.MapPath(branch.BranchPicturePath));

                }

                bool resultDelete = _branchBll.Delete(branch.id);
                if (resultDelete)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            return 0;
        }
    }
}