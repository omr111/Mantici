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
        IBranchesApplicationBll _applicationBll=new BranchesApplicationBll(new BranchesApplicationDal());
        // GET: AdminPanel/Branches
        [Authorize]
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

            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
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
                    return RedirectToAction("Index", "Branches", new { area = "AdminPanel" });
                }
                ViewData["branchAddingError"] = "Lütfen Tüm Verileri Eksiksiz Girin !";
                return View();
               
            }
            catch (Exception e)
            {
                ViewData["branchAddingError"] = "Lütfen Tüm Verileri Eksiksiz Girin !";
                return View();
            }
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

        public ActionResult branchUpdate(int id)
        {
            Branch branch = _branchBll.GetOne(id);
            if (branch!=null)
            {
                return View(branch);
            }
            else
            {
                TempData["branchUpdateError"] = "Güncellemek İstediğiniz Bayi Bulunamadı !";
                return RedirectToAction("Index","Branches",new{area="AdminPanel"});
            }
        
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult branchUpdate(Branch br, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Branch branch = _branchBll.GetOne(br.id);
                    if (branch != null)
                    {
                        if (file != null)
                        {
                            if (System.IO.File.Exists(Server.MapPath(branch.BranchPicturePath)))
                            {
                                System.IO.File.Delete(Server.MapPath(branch.BranchPicturePath));

                            }

                            branch.BranchPicturePath = pictureController.pictureAddForBranch(file, HttpContext);
                            branch.pictureAlt = br.pictureAlt;
                        }

                        branch.BranchName = br.BranchName;
                        branch.area = br.BranchAdress;
                        branch.city = br.city;
                        branch.email = br.email;
                        branch.BranchAdress = br.BranchAdress;

                        bool resultUpdate = _branchBll.Update(branch);
                        if (resultUpdate)
                        {
                            return RedirectToAction("Index", "Branches", new { area = "AdminPanel" });
                        }
                        else
                        {
                            TempData["branchUpdateError"] = "Bayi Güncellenemedi,Lütfen Tekrar Deneyin";

                            return View();
                        }

                    }
                    else
                    {
                        TempData["branchUpdateError"] = "Güncellemek İstediğiniz Bayi Bulunamadı !";

                        return View();
                    }

                }
                else
                {
                    TempData["branchUpdateError"] = "Geçersiz Veriler Kayıt Edilmeye Çalışıldı !";

                    return View();
                }

            }
            catch (Exception e)
            {
                TempData["branchUpdateError"] = e.Message;

                return View();
            }
        }
        [HttpPost]
        public string phoneAdd(int companyId, string selectedPhone)
        {

            BranchPhone phone;
            phone = _branchPhone.GetOne(selectedPhone, companyId);
            if (phone == null && selectedPhone.Trim() != "")
            {
                phone = new BranchPhone();
                phone.BranchID = companyId;
                phone.BranchPhone1 = selectedPhone;
                bool result = _branchPhone.Add(phone);
                if (result)
                {
                    return selectedPhone;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }

        }

        [HttpPost]
        public JsonResult phoneDelete(int companyId, string selectedPhone)
        {
            BranchPhone phone = _branchPhone.GetOne(selectedPhone, companyId);
            if (phone != null && selectedPhone.Trim() != "")
            {
                bool resultDelete = _branchPhone.Delete(phone.id);
                if (resultDelete)
                {

                    return Json(data: 1);
                }
                else
                {
                    return Json(data: 0);
                }
            } return Json(data: 0);
        }

        public ActionResult branchRequestList()
        {
            return View(_applicationBll.ListAll());
        }
        [HttpPost]
        public int branchRequestDelete(int id)
        {

            BranchesApplication app = _applicationBll.GetOne(id);

            if (app != null)
            {

                bool resultDelete = _applicationBll.Delete(app.id);
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