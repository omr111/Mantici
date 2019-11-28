using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Drawing;
using Mantici.MVCWebUI.App_Classes;
using System.IO;
using Image = System.Drawing.Image;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class CompanyController : Controller
    {
        IPhoneBll _phoneBll=new PhoneBll(new PhoneDal());
        ICompanyInformationBll _companyInformation=new CompanyInformationBll(new CompanyInformationDal());
        // GET: AdminPanel/Company
        public ActionResult Index()
        {
            CompanyInformation company = _companyInformation.GetOneWitId(2);
           
            return View(company);
        }
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult companyEdit(CompanyInformation comInfo, HttpPostedFileBase companyLogo, HttpPostedFileBase companyPicturePath)
        {
            CompanyInformation company = _companyInformation.GetOneWitId(2);


            try
            {
                if (ModelState.IsValid)
                {
                    if (companyPicturePath != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(company.companyPicturePath)))
                        {
                            FileStream fs = new FileStream(Server.MapPath(company.companyPicturePath), FileMode.OpenOrCreate);

                            fs.Flush();
                            fs.Close();

                            System.IO.File.Delete(Server.MapPath(company.companyPicturePath));

                        }

                        int companyPictureWidth = settings.companyPicture.Width;
                        int companyPictureHeight = settings.companyPicture.Height;
                        string newName = Path.GetFileNameWithoutExtension(companyPicturePath.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(companyPicturePath.FileName);

                        Image orjCompany = Image.FromStream(companyPicturePath.InputStream);
                        Bitmap companyPicturDraw = new Bitmap(orjCompany, companyPictureHeight, companyPictureWidth);
                        companyPicturDraw.Save(Server.MapPath("~/content/img/companyPicture/" + newName));

                        company.companyPicturePath = "/content/img/companyPicture/" + newName;

                    }

                    if (companyLogo != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(company.companyLogo)))
                        {

                            System.IO.File.Delete(Server.MapPath(company.companyLogo));

                        }

                        int companyLogoWidth = settings.companyLogo.Width;
                        int companyLogoHeight = settings.companyLogo.Height;
                        string newName = Path.GetFileNameWithoutExtension(companyLogo.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(companyLogo.FileName);
                        Image orjResim = Image.FromStream(companyLogo.InputStream);
                        Bitmap companyLogoDraw = new Bitmap(orjResim, companyLogoWidth, companyLogoHeight);
                        companyLogoDraw.Save(Server.MapPath("~/content/img/logo/" + newName));

                        company.companyLogo = "/content/img/logo/" + newName;
                    }
                    company.companyAbout = comInfo.companyAbout;
                    company.companyAddress = comInfo.companyAddress;
                    company.companyName = comInfo.companyName;
                    company.email = comInfo.email;
                    company.videoPath = comInfo.videoPath;
                    company.videoText = comInfo.videoText;
                    company.videoText = comInfo.videoText;
                

                   
                    bool result = _companyInformation.Update(company);
                    //todo uyarı mesajları yapılacak.
                    if (result)
                    {
                        return RedirectToAction("Index", "Company", new { area = "AdminPanel" });
                    } return RedirectToAction("Index", "Company", new { area = "AdminPanel" });
                }
                else
                {
                    return View("Index", company);
                }

               
            }
            catch (Exception e)
            {

                return View("Index");
            }
          
            
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string phoneAdd(int companyId, string selectedPhone)
        {
           
                Phone phone;
                phone = _phoneBll.GetOne(selectedPhone, companyId);
                if (phone == null &&selectedPhone.Trim() != "")
                {
                    phone = new Phone();
                    phone.CompanyID = companyId;
                    phone.phoneNumber = selectedPhone;
                    bool result = _phoneBll.Add(phone);
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
            Phone phone = _phoneBll.GetOne(selectedPhone, companyId);
            if (phone!=null&& selectedPhone.Trim()!="")
            {
                bool resultDelete = _phoneBll.Delete(phone.id);
                if (resultDelete)
                {
                    
                    return Json(data:1);
                }
                else
                {
                    return Json(data:0);
                }
            } return Json(data: 0);
        }
    }
}