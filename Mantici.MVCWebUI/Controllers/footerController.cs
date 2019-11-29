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
    public class footerController : Controller
    {
        IProductBll _productBll=new ProductBll(new ProductDal());
        // GET: footer
        public ActionResult Index()
        {
          
            return View();
        }
    }
}