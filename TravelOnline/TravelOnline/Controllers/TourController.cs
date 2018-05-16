using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/

        public ActionResult Index()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            return View();
        }

        public ActionResult DetailTour(int id)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            ViewBag.DetailTour =  new TourDAO().ViewDetail(id);
            return View();
        }

        public ActionResult TourNuocNgoai(int page = 1, int pageSize = 8)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var tourDAO = new TourDAO();
            var model = tourDAO.GetListTourOfCategory("Quốc tế", page, pageSize);
            //ViewBag.TourOfCategory = tourDAO.GetListTourOfCategory("Quốc tế");
            return View(model);
        }

        public ActionResult TourTrongNuoc(int page = 1, int pageSize = 8)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var tourDAO = new TourDAO();
            var model = tourDAO.GetListTourOfCategory("Trong nước", page, pageSize);
            return View(model);
        }

        public ActionResult TourKhuyenMai(int page = 1, int pageSize = 8)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var tourDAO = new TourDAO();
            var model = tourDAO.GetTourKhuyenMai(page, pageSize);
            return View(model);
        }

        public ActionResult LichKhoiHanh()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var tourDAO = new TourDAO();
            ViewBag.LichKhoiHanh = tourDAO.GetTourGanDay(20);
            return View();
        }

        public ActionResult Search(int diemden, int giatour, string khoihanh)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var dao = new TourDAO();
            ViewBag.Tour = dao.SearchTour(diemden, giatour, khoihanh);
            return View();
        }

    }
}
