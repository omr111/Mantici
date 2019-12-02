using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.MVCWebUI.Models;

namespace Mantici.MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        IbannerBll _bannerBll=new bannerBll(new bannerDal());
        IserviceBll _serviceBll=new serviceBll(new serviceDal());
        IProductBll _productBll=new ProductBll(new ProductDal());
       ICompanyInformationBll _company=new CompanyInformationBll(new CompanyInformationDal());
       IreviewBll _reviewBll=new reviewBll(new reviewDal());
        // GET: Home
        public ActionResult Index()
        {
            HomeModels homeModels=new HomeModels();
            //homeModels.Banners = _bannerBll.defaultBannerList();
            homeModels.Services = _serviceBll.defaultServiceList().OrderByDescending(x => x.id).Take(6).ToList();;
            homeModels.menuList = _productBll.ListAll().Take(6).ToList();
            homeModels.menuSliders=_productBll.ListAll().OrderByDescending(x => x.id).ToList();;
            homeModels.company = _company.GetOneWitId(2);
            homeModels.Reviews = _reviewBll.ListAll();
            return View(homeModels);
        }

        public PartialViewResult slider()
        {
            return PartialView(_bannerBll.defaultBannerList());
        }

        public PartialViewResult footer()
        {
            ViewBag.productToFooter = _productBll.ListAll().OrderByDescending(x => x.id).Take(4);
            return PartialView(_company.GetOneWitId(2));

        }

        public PartialViewResult logo()
        {
            return PartialView(_company.GetOneWitId(2));
        }

        public PartialViewResult MobilLogo()
        {
            return PartialView(_company.GetOneWitId(2));
        }

        public PartialViewResult favicon()
        {
            return PartialView(_company.GetOneWitId(2));
        }
    }
}