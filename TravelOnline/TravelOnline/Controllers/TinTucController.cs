using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace TravelOnline.Controllers
{
    public class TinTucController : Controller
    {
        //
        // GET: /TinTuc/

        public ActionResult Index(int page=1,int pageSize=6)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var dao = new TinTucDAO();
            var model = dao.ListAll(page, pageSize);
            ViewBag.News = dao.ListAll(page, pageSize);
            return View(model);
        }

        public ActionResult DetailNews(int id)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var tour = new TinTucDAO().ViewDetail(id);
          
            return View(tour);
        }

    }
}
