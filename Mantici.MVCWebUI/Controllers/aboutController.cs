using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Controllers
{
    public class aboutController : Controller
    {
      ICompanyInformationBll _companyInformationBll =new CompanyInformationBll(new CompanyInformationDal());
       // GET: about
        public ActionResult Index()
        {

            return View(_companyInformationBll.GetOneWitId(2));
        }
      

    }
}