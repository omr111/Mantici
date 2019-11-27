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
    public class serviceController : Controller
    {
        IserviceBll _serviceBll=new serviceBll(new serviceDal());
        // GET: AdminPanel/service
        public ActionResult Index()
        {

            return View(_serviceBll.defaultServiceList());
        }

        public ActionResult serviceAdd()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult serviceAdd(service srv, HttpPostedFileBase file)
        {
            //todo resim null gelirse hata verdir.
            if (ModelState.IsValid)
            {
                if (file!=null)
                {
                    srv.serviceIcon = pictureController.IconAddForService(file, HttpContext);
                }
         

                _serviceBll.addService(srv);
                return RedirectToAction("Index", "service", new { area = "AdminPanel" });
            }
            else
            {
                return View("serviceAdd");
            }
        }
        [HttpPost]
        public int serviceDelete(int id)
        {

            service service = _serviceBll.getOneWithId(id);

            if (service != null)
            {


                if (System.IO.File.Exists(Server.MapPath(service.serviceIcon)))
                {
                    System.IO.File.Delete(Server.MapPath(service.serviceIcon));

                }

                bool resultDelete = _serviceBll.deleteService(service.id);
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

        public ActionResult serviceUpdate(int id)
        {
            service service = _serviceBll.getOneWithId(id);

            if (service != null)
            {

                return View(service);
            }
            else
            {
                TempData["serviceUpdateError"] = "Güncellemek İstediğiniz Servis Bulunamadı !";
                return RedirectToAction("Index", "service", new { area = "AdminPanel" });
            }


        }
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult serviceUpdate(service svr, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service service = _serviceBll.getOneWithId(svr.id);
                    if (service != null)
                    {
                        if (file != null)
                        {
                            if (System.IO.File.Exists(Server.MapPath(service.serviceIcon)))
                            {
                                System.IO.File.Delete(Server.MapPath(service.serviceIcon));

                            }

                            service.serviceIcon = pictureController.IconAddForService(file, HttpContext);
                     
                        }

                        service.serviceName = svr.serviceName;
                        service.serviceInfo = svr.serviceInfo;


                        bool resultUpdate = _serviceBll.update(service);
                        if (resultUpdate)
                        {
                            return RedirectToAction("Index", "service", new { area = "AdminPanel" });
                        }
                        else
                        {
                            TempData["serviceUpdateError"] = "Servis Güncellenemedi,Lütfen Tekrar Deneyin";

                            return View();
                        }

                    }
                    else
                    {
                        TempData["serviceUpdateError"] = "Güncellemek İstediğiniz Servis Bulunamadı !";

                        return View();
                    }

                }
                else
                {
                    TempData["serviceUpdateError"] = "Geçersiz Veriler Kayıt Edilmeye Çalışıldı !";

                    return View();
                }

            }
            catch (Exception e)
            {
                TempData["serviceUpdateError"] = e.Message;

                return View();
            }
        }
    }
}