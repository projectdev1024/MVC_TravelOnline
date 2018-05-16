using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var tourDAO = new TourDAO();
            var tintucDAO = new TinTucDAO();
           
            ViewBag.NewTour = tourDAO.ListNewTour(4);
            ViewBag.News = tintucDAO.ListNews(3);
            ViewBag.TourGanDay = tourDAO.GetTourGanDay(5);
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            return View();
        }

        public ActionResult GioiThieu()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            return View();
        }

    }
}
