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
    public class reservationController : Controller
    {
        IrezervationBll _rezervationBll=new rezervationBll(new rezervationDal());
        // GET: reservation
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(rezervation rezervation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rezervation.showed = false;
                    bool result = _rezervationBll.Add(rezervation);
                    if (result)
                    {
                        ViewData["reservationInfo"] = "Rezervasyon İşleminiz Başarıyla Yapıldı.";
                        return View("Index");

                    }
                    else
                    {
                        ViewData["reservationInfo"] = "Rezervasyon Sırasında Bir Hata Meydana Geldi. Lütfen Tekrar Deneyiniz.";
                        return View("Index");
                    }
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                ViewData["reservationInfo"] = "Rezervasyon Sırasında Bir Hata Meydana Geldi. Lütfen Tekrar Deneyiniz.";
                return View("Index");
            }
           
        }
    }
}