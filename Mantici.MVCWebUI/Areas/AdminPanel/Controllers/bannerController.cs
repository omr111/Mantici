using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;
using Mantici.MVCWebUI.App_Classes;
using System.Drawing;
using System.IO;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class bannerController : Controller
    {
        IbannerBll _bannerBll=new bannerBll(new bannerDal());
        // GET: AdminPanel/banner
        public ActionResult Index()
        {
            List<banner> banners = _bannerBll.defaultBannerList();
            if (banners!=null)
            {
                return View(banners);
            }
            return View();
        }
        [HttpPost]
        public ActionResult bannerAdd(string text, HttpPostedFileBase companyPicturePath)
        {

            try
            {
                if (ModelState.IsValid &&!string.IsNullOrEmpty(text)&& companyPicturePath!=null)
                {
                    int picWidth = settings.bannerPicture.Width;
                    int pichHeight = settings.bannerPicture.Height;
                    string newName = Path.GetFileNameWithoutExtension(companyPicturePath.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(companyPicturePath.FileName);
                    Image orjResim = Image.FromStream(companyPicturePath.InputStream);
                    Bitmap pictureDraw = new Bitmap(orjResim, picWidth, pichHeight);
                    if (Directory.Exists(Server.MapPath("/content/img/bannerPicture")))
                    {
                        pictureDraw.Save(Server.MapPath("/content/img/bannerPicture/" + newName));
                    }

                    banner bnr = new banner();
                    bnr.text = text;
                    bnr.bannerPath = "/content/img/bannerPicture/" + newName;
                    //resmin alt'ı olarak kullanacağım filename'i
                    bnr.altName = companyPicturePath.FileName;
                    bool result = _bannerBll.addBanner(bnr);
                    Session["bannerEklenemedi"] = "";
                    if (result)
                    {
                        Session["bannerEklenemedi"] = "Banner Başarıyla Eklendi";
                        return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                    }
                    else
                    {
                        Session["bannerEklenemedi"] = "Banner Kaydı Sırasında Bir Hata Oluştu!";

                        return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                    }
                }
               
                else
                {
                    Session["bannerEklenemedi"] = "Lütfen İlgili Alanları Doldurunuz.";
                    return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                }
            }
            catch (Exception e)
            {
                Session["bannerEklenemedi"] = e.Message;
                return RedirectToAction("Index", "banner", new {area = "AdminPanel"});
            }



            
        }

        [HttpPost]
        public ActionResult bannerDelete(int id)
        {
            try
            {
                banner bnr = _bannerBll.getOneWithId(id);
                if (bnr!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(bnr.bannerPath)))
                    {
                        System.IO.File.Delete(Server.MapPath(bnr.bannerPath));

                    }

                    bool resultDeleteBanner = _bannerBll.deleteBanner(id);

                    if (resultDeleteBanner)
                    {
                        return Json(new { id = 1, message = "Banner Başarıyla Silindi." });
                    }
                    else
                    {
                        return Json(new { id = 0, message = "Bu Banner Silinemedi, Başka Bir Yerde Kullanılıyor Olabilir !" });
                    }

                }
                else
                {
                    return Json(new { id = 0, message = "Silmek İstediğiniz Banner Bulunamadı!" });
                }
               
                
            }
            catch (Exception e)
            {
                return Json(new { id = 0, message =e.Message });
            }
        }
    }
}