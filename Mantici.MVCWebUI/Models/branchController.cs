using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;

namespace Mantici.MVCWebUI.Models
{
    public class branchController : Controller
    {
        IBranchBll _branchBll=new BranchBll(new BranchDal());
        // GET: branch
        public ActionResult Index()
        {
            return View(_branchBll.ListAll());
        }
    }
}