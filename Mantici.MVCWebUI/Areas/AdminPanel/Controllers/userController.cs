using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;
using Mantici.MVCWebUI.Areas.AdminPanel.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class userController : Controller
    {
        IuserBll _userBll=new userBll(new userDal());
        IroleBll _roleBll=new roleBll(new roleDal());
        // GET: AdminPanel/user
        public ActionResult Index()
        {
            usersAndRoles usersAndRoles=new usersAndRoles();
            usersAndRoles.Users=_userBll.whereRole("Uye");
            usersAndRoles.Roles = _roleBll.ListAll();
            return View(usersAndRoles);
        }

        public ActionResult managementTeam()
        {
            return View(_userBll.managementTeam("Uye"));
        }
        public ActionResult userBlock(int id)
        {
            
             user usr=_userBll.GetOne(id);

             if (usr.isBlock)
            {
                usr.isBlock = false;
            }
            else
            {
                usr.isBlock = true;
            }

             _userBll.Update(usr);
            return RedirectToAction("Index", "user",new {area="AdminPanel"});
        }
        public ActionResult managerBlock(int id)
        {

            user usr = _userBll.GetOne(id);

            if (usr.isBlock)
            {
                usr.isBlock = false;
            }
            else
            {
                usr.isBlock = true;
            }

            _userBll.Update(usr);
            return RedirectToAction("managementTeam", "user", new { area = "AdminPanel" });
        }
    }
}