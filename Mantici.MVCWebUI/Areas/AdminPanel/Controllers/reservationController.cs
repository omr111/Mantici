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
    public class reservationController : Controller
    {
        IrezervationBll _rezervationBll=new rezervationBll(new rezervationDal());
        // GET: AdminPanel/reservation
        public ActionResult Index()
        {
            List<rezervation> rezervations = _rezervationBll.ListAll();
            return View(rezervations);
        }

        [HttpPost]
        public int deleteReservation(int id)
        {

            bool result = _rezervationBll.Delete(id);
               if (result)
               {
                   return 1;
               } return 0;
            
        }

        [HttpPost]
        public int reservationShowed(int id)
        {
            rezervation rez = _rezervationBll.GetOne(id);
            if (ModelState.IsValid)
            {
                rez.showed = true;
                bool result = _rezervationBll.Update(rez);
                if (result)
                {
                    return 1;
                }

                return 0;
            }
            return 0;
           
        }
    }
}