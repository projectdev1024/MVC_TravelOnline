using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelOnline.Models;

namespace TravelOnline.Areas.Admin.Controllers
{
    public class DatTourController : BaseController
    {
        //
        // GET: /Admin/DatTour/

        public ActionResult Index()
        {
            var dao = new DatTourDAO();
            ViewBag.TourChuaThanhToan = dao.TourChuaThanhToan();
            return View();
        }

        public ActionResult ChiTietDatTour(int id)
        {
            var dao = new DatTourDAO();
            ViewBag.TourChuaThanhToan = dao.TourChuaThanhToan(id);
            return View();
        }

        public ActionResult XacNhanThanhToan(int id)
        {
            var dao = new DatTourDAO();
            var daoTour = new TourDAO();
            //Cập nhật trạng thái thanh toán
            
            var dattour = dao.TourChuaThanhToan(id);
            var tour = daoTour.ViewDetail(dattour.matour);

            //Trừ số chỗ
            int sochodattour = dattour.sotreem.Value + dattour.songuoilon.Value;
            int socho = tour.socho.Value;
            if (sochodattour > socho)
            {
                Session["Error"] = "Hiện tour đã hết chỗ";
                return RedirectToAction("ChiTietDatTour", "DatTour", new { id = id });
            }
            else
            {
                bool result = dao.XacNhanThanhToan(id);
                daoTour.CapNhatSoCho(dattour.matour, sochodattour);
            }
           
            ViewBag.TourDaThanhToan = dao.TourDaThanhToan(id);
            return View();
        }

        public ActionResult HuyTour(int id)
        {
            var dao = new DatTourDAO();
            bool result = dao.Delete(id);
            return RedirectToAction("Index", "DatTour");
        }

        public ActionResult DanhSachTourDaDat(int id)
        {
            var model = new DatTourDAO().DanhSachTourDaDat(id);
            ViewBag.Tour = new TourDAO().ViewDetail(id);
            return View(model);
        }
    }
}
