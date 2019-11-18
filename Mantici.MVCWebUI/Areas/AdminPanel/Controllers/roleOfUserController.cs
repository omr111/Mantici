using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class roleOfUserController : Controller
    {
        IroleOfUserBll _roleOfUserBll =new roleOfUserBll(new roleOfUserDal());
        // GET: AdminPanel/roleOfUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult roleDismiss(int roleId,int userId)
        {
            try
            {

                int role_id = _roleOfUserBll.GetOneWithRoleId(roleId, userId).id;
                if (role_id>0)
                {
                    bool result = _roleOfUserBll.Delete(role_id);
                    if (result)
                    {
                        roleOfUser isHave = _roleOfUserBll.CheckRoleOfUser(userId);
                        if (isHave == null)
                        {
                            roleOfUser roleOfUsr = new roleOfUser();
                            roleOfUsr.roleID = 4;//Uye
                            roleOfUsr.userID = userId;
                            _roleOfUserBll.Add(roleOfUsr);
                        }
                        return Json(data: 1);
                    }
                    else
                    {
                        return Json(data: 0);
                    }
                }
                else
                {
                    return Json(data: 0);
                }
            }
            catch (Exception e)
            {
                return Json(data: 0);
            }

           
        }
        [HttpPost]
        public ActionResult giveRole(int userId, int roleId)
        {
            try
            {
                roleOfUser role=new roleOfUser();
                role.roleID = roleId;
                role.userID = userId;
                roleOfUser isThere=_roleOfUserBll.GetOneWithRoleId(roleId, userId);
                if (isThere==null)
                {
                    bool result= _roleOfUserBll.Add(role);
                    if (result)
                    {
                        return Json(data: 1);
                    }
                    else
                    {
                        return Json(data: 0); 
                    }
                }
                else
                {
                    return Json(data: 0);
                }
            }
            catch (Exception e)
            {
                return Json(data: 0);
            }

        }
    }
}