using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.MVCWebUI.Areas.AdminPanel.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    
    public class HomeController : Controller
    {
        IuserBll _userBll=new userBll(new userDal());
        IProductBll _productBll=new ProductBll(new ProductDal());
        IBranchBll _branchBll=new BranchBll(new BranchDal());
        IrezervationBll _rezervationBll=new rezervationBll(new rezervationDal());
        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            AdminIndex adminIndex=new AdminIndex();
            adminIndex.Products = _productBll.ListAll();
            adminIndex.Branches = _branchBll.ListAll();
            adminIndex.Rezervations = _rezervationBll.ListAll();
            adminIndex.Users = _userBll.ListAll();
            adminIndex.managementTeam = _userBll.managementTeam("Uye");
            return View(adminIndex);
        }
    }
}