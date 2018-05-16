using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Areas.Admin.Controllers
{
    public class LienHeController : Controller
    {
        //
        // GET: /Admin/LienHe/

        public ActionResult Index()
        {
            var dao = new LienHeDAO();
            var model = dao.LayThongTinLienHe();
            return View(model);
        }

        public ActionResult Edit()
        {
            var dao = new LienHeDAO();
            var model = dao.LayThongTinLienHe();
            return View(model);
        }

    }
}
