using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;

namespace Mantici.MVCWebUI.Controllers
{
    public class servicesController : Controller
    {
        IserviceBll _serviceBll =new serviceBll(new serviceDal());
        // GET: services
        public ActionResult Index()
        {
            return View(_serviceBll.defaultServiceList().OrderByDescending(x=>x.id).ToList());
        }
    }
}