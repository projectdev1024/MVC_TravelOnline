using Common;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelOnline.Common;

namespace TravelOnline.Controllers
{
    public class DatTourController : Controller
    {
        //
        // GET: /DatTour/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DatTour(int id)
        {
            ViewBag.DetailTour = new TourDAO().ViewDetail(id);
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
            if (session == null)
                return RedirectToAction("Login", "KhachHang");
            var dao = new DatTourDAO();
            bool result = dao.CheckDatTour(session.UserID);
            if (result==false)
            {
                return RedirectToAction("TourCuaToi", "KhachHang");
            }
                

            ViewBag.ThongTinKhachHang = new KhachHangDAO().ViewDetail(session.UserID);
            return View();
        }

        [HttpPost]
        public ActionResult DatTour(tblDATTOUR dattour)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            if (ModelState.IsValid)
            {
                int? socho = new TourDAO().ViewDetail(dattour.matour).socho;
                if (dattour.sotreem == null)
                    dattour.sotreem = 0;
                int soChoDat = dattour.songuoilon.Value + dattour.sotreem.Value;
                if (socho < soChoDat)
                {
                    ViewBag.Error = "Số chỗ còn trống không đủ";
                    ViewBag.DetailTour = new TourDAO().ViewDetail(dattour.matour);
                    var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
                    if (session == null)
                        return RedirectToAction("Login", "KhachHang");
                    ViewBag.ThongTinKhachHang = new KhachHangDAO().ViewDetail(session.UserID);
                    return View();
                }
                else
                {
                    //Insert vào table Dattour
                    var dao = new DatTourDAO();
                    double giatour;
                    var tourDAO = new TourDAO();
                    var tour = tourDAO.ViewDetail(dattour.matour);
                    if (tour.giakhuyenmai != null)
                    {
                        giatour = tour.giakhuyenmai.Value;
                    }
                    else
                    {
                        giatour = tour.giatour.Value;
                    }

                    //Gia tour tre em
                    double giaTourTreEm = giatour - giatour * 5 / 100;

                    dattour.tongtien = giatour * dattour.songuoilon.Value + giaTourTreEm * dattour.sotreem.Value;
                    long id = dao.Insert(dattour);
                  
                    var tourSession = new ThongTinDatTour();
                    tourSession.hoten = dattour.hoten;
                    tourSession.matour = dattour.matour;
                    tourSession.cmt = dattour.cmt;
                    tourSession.diachi = dattour.diachi;
                    tourSession.dienthoai = dattour.dienthoai;
                    tourSession.email = dattour.email;
                    tourSession.songuoilon = dattour.songuoilon;
                    tourSession.sotreem = dattour.sotreem;
                    tourSession.tongtien = dattour.tongtien;
                    Session.Add(CommonConstants.DATTOUR_SESSION, tourSession);
                    //Trừ số chỗ Tour
                    //bool result = tourDAO.CapNhatSoCho(tour.matour, soChoDat);
                    //View hoàn thành
                    return Redirect("/dat-tour/thanh-cong");
                }

            }
            else
            {
                ViewBag.DetailTour = new TourDAO().ViewDetail(dattour.matour);
                var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
                if (session == null)
                    return RedirectToAction("Login", "KhachHang");
                ViewBag.ThongTinKhachHang = new KhachHangDAO().ViewDetail(session.UserID);
                return View();
            }
           
        }

        public ActionResult DatTourThanhCong()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var session = (TravelOnline.Common.ThongTinDatTour)Session[TravelOnline.Common.CommonConstants.DATTOUR_SESSION];     
            if (session==null)
                return RedirectToAction("Index", "Home"); 
            else
            {
                //string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/templates/dattour.html"));
                //string name = "<title>Thông tin đặt tour1</title>";
                //content = content.Replace("<title>Thông tin đặt tour</title>\r\n", name);
                //new MailHelper().SendMail("nguyenvtienhaui@gmail.com", "Thông tin đặt tour", content);
                ViewBag.DetailTour = new TourDAO().ViewDetail(session.matour);
            }

            return View();
        }

        [HttpGet]
        public ActionResult SuaTour(int id)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var dao = new DatTourDAO();
            ViewBag.TTDatTour = dao.TourChuaThanhToan(id);
            return View();
        }

        [HttpPost]
        public ActionResult SuaTour(tblDATTOUR model)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var dao = new DatTourDAO();
            ViewBag.TTDatTour = dao.TourChuaThanhToan(model.madattour);
            if (ModelState.IsValid)
            {

                int? socho = new TourDAO().ViewDetail(model.matour).socho;
                if (model.sotreem == null)
                    model.sotreem = 0;
                int soChoDat = model.songuoilon.Value + model.sotreem.Value;
                if (socho < soChoDat)
                {
                    ViewBag.Error = "Số chỗ còn trống không đủ . Hiện số chỗ còn "+socho+" chỗ";
                    ViewBag.DetailTour = new TourDAO().ViewDetail(model.matour);
                    var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
                    if (session == null)
                        return RedirectToAction("Login", "KhachHang");
                    ViewBag.ThongTinKhachHang = new KhachHangDAO().ViewDetail(session.UserID);
                    return View();
                }
                else
                {
                    double giatour;
                    var tourDAO = new TourDAO();
                    var tour = tourDAO.ViewDetail(model.matour);
                    if (tour.giakhuyenmai != null)
                    {
                        giatour = tour.giakhuyenmai.Value;
                    }
                    else
                    {
                        giatour = tour.giatour.Value;
                    }

                    //Gia tour tre em
                    double giaTourTreEm = giatour - giatour * 5 / 100;
                    model.tongtien = giatour * model.songuoilon.Value + giaTourTreEm * model.sotreem.Value;
                    bool result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("TourCuaToi", "KhachHang");
                    }
                }
               
            }
            return View();
        }

        public ActionResult HuyTour(int id)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var dao = new DatTourDAO();
            bool result = dao.Delete(id);
            return RedirectToAction("TourCuaToi", "KhachHang");
        }

    }
}
