using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Controllers
{
    public class LienHeController : Controller
    {
        //
        // GET: /LienHe/

        public ActionResult Index()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            return View();
        }

    }
}
