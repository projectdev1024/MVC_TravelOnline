using BotDetect.Web.Mvc;
using Common;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TravelOnline.Common;
using TravelOnline.Models;

namespace TravelOnline.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        [HttpGet]
        public ActionResult Register()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Captcha không chính xác")]
        public ActionResult Register(DangKyModel model)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDAO();
                if (dao.kiemTraTaiKhoan(model.taikhoan)>0)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.kiemTraEmail(model.email)>0)
                {
                    ModelState.AddModelError("", "Tên email đã tồn tại");
                }
                else
                {
                    var khachhang = new tblKHACHHANG();
                    khachhang.taikhoan = model.taikhoan;
                    khachhang.hoten = model.hoten;
                    khachhang.ngaysinh = model.ngaysinh;
                    khachhang.cmt = model.cmt;
                    khachhang.diachi = model.diachi;
                    khachhang.dienthoai = model.dienthoai;
                    khachhang.gioitinh = model.gioitinh;
                    khachhang.email = model.email;
                    var encrytedMd5Pas = Encryptor.MD5Hash(model.matkhau);
                    khachhang.matkhau = encrytedMd5Pas;
                    var result = dao.Insert(khachhang);
                    if (result>0)
                    {
                        Session["Register"] = "Đăng ký";
                        return RedirectToAction("Login", "KhachHang");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var userSession = new UserLogin();
                    var user = dao.GetByID(model.UserName);
                    userSession.UserID = user.makh;
                    userSession.UserName = user.taikhoan;
                    Session.Add(CommonConstants.CUSTOMER_SESSION, userSession);
                    return Redirect("/");
                }
                else
                {
                    if (result == -2)
                        ModelState.AddModelError("", "Mật khẩu không chính xác");
                       
                    else
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
            }
            
            return View(model);
        }

        public ActionResult Logout()
        {

            Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION] = null;
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult UpdateProfile()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
            if (session == null)
                return RedirectToAction("Login", "KhachHang");
            ViewBag.ThongTinKhachHang = new KhachHangDAO().ViewDetail(session.UserID);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProfile(CapNhatThongTinModel model)
        {
            var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
            var khachhang = new tblKHACHHANG();
            var dao = new KhachHangDAO();
            if (session == null)
                return RedirectToAction("Login", "KhachHang");
            if (ModelState.IsValid)
            {
                if (model.matkhaucu == null) 
                {
                    khachhang.matkhau = dao.GetByID(model.taikhoan).matkhau;
                }
                else
                {

                        var matkhaucu = dao.GetByID(model.taikhoan).matkhau;
                        var matkhau = Encryptor.MD5Hash(model.matkhaucu);
                        if (matkhaucu != matkhau)
                        {
                            ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                            ViewBag.ThongTinKhachHang = new KhachHangDAO().ViewDetail(session.UserID);
                            return View();
                        }
                        else
                        {
                            if (model.matkhau == null)
                            {
                                ModelState.AddModelError("", "Vui lòng nhập mật khẩu mới");
                                ViewBag.ThongTinKhachHang = new KhachHangDAO().ViewDetail(session.UserID);
                                return View();
                            }
                            else
                            {
                                var encrytedMd5Pas = Encryptor.MD5Hash(model.matkhau);
                                khachhang.matkhau = encrytedMd5Pas;
                            }

                        }
                 
                  
                }

                    khachhang.taikhoan = model.taikhoan;
                    khachhang.hoten = model.hoten;
                    khachhang.ngaysinh = model.ngaysinh;
                    khachhang.cmt = model.cmt;
                    khachhang.diachi = model.diachi;
                    khachhang.dienthoai = model.dienthoai;
                    khachhang.gioitinh = model.gioitinh;
                    khachhang.email = model.email;
                    khachhang.makh = model.makh;
                    
                    var result = dao.Update(khachhang);
                    if (result ==true)
                    {
                        ViewBag.Success = "Cập nhật thành công !";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công");
                    }
              
                
            }
            ViewBag.ThongTinKhachHang = new KhachHangDAO().ViewDetail(session.UserID);

            return View(model);
        }

        public ActionResult TourCuaToi()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
            if (session == null)
                return RedirectToAction("Login", "KhachHang");
            else
            {
                var dao = new DatTourDAO();
                ViewBag.TourChuaThanhToan = dao.TourChuaThanhToanTheoKhachHang(session.UserID);
            }
            return View();
        }

        [HttpGet]
        public ActionResult LayLaiMatKhau()
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
            if (session != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult LayLaiMatKhau(LayLaiMatKhauModel model)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
            if (session != null)
                return RedirectToAction("Index", "Home");

            var dao = new KhachHangDAO();
            bool kiemTraTaiKhoanEmail = dao.kiemTraTaiKhoanEmail(model.taikhoan, model.email);
            if (kiemTraTaiKhoanEmail==false)
            {
                ViewBag.Loi = "Thông tin bạn nhập không chính xác!";
            }
            else
            {
                //Tạo mã random
                string rdCode = RandomString(30, true);
                //Thêm vào table Khách hàng
                bool result = dao.UpdateRDCode(model.taikhoan, rdCode);
                //Gửi email xác nhận mật khẩu
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/templates/laylaimatkhau.html"));
                string urlHome = ConfigurationManager.AppSettings["UrlHome"].ToString();
                string link = urlHome+"/khach-hang/cap-nhat-mat-khau/?taikhoan=" + model.taikhoan + "&email=" + model.email + "&rdcode=" + rdCode;
                content = content.Replace("{{Link}}", link);
                new MailHelper().SendMail(model.email, "Xác nhận thay đổi mật khẩu", content);
                ViewBag.ThanhCong = "<strong>Hoàn thành!</strong> . Vui lòng xác nhận qua email";
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult CapNhatMatKhau(string taikhoan,string email,string rdcode)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
            if (session != null)
                return RedirectToAction("Index", "Home");
            //Kiểm tra tài khoản, email và rdcode
            var dao = new KhachHangDAO();
            bool result = dao.KiemTraTaiKhoanEmailRDCode(taikhoan, email, rdcode);
            if (result==false)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CapNhatMatKhau(CapNhatMatKhauModel model)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            if (ModelState.IsValid)
            {
                var session = (TravelOnline.Common.UserLogin)Session[TravelOnline.Common.CommonConstants.CUSTOMER_SESSION];
                if (session != null)
                    return RedirectToAction("Index", "Home");
                var dao = new KhachHangDAO();
                //Kiểm tra tài khoản
                int kiemtrataikhoan = dao.kiemTraTaiKhoan(model.taikhoan);
                
                if (kiemtrataikhoan==0)
                {
                    ViewBag.Loi = "Tài khoản không tồn tại!";
                }
                else 
                {
                    //Thay đổi RdCode
                    string rdcode = RandomString(30, true);
                    //Cập nhật
                    bool result = dao.CapNhatMatKhau(model.taikhoan, Encryptor.MD5Hash(model.matkhau), rdcode);
                   if (result== true)
                   {
                       ViewBag.ThanhCong = "Cập nhật mật khẩu thành công";
                   }
                   else
                   {
                       ViewBag.Loi = "Cập nhật không thành công";
                   }

                }
                
        
            }
            return View(model);
        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
                return sb.ToString().ToLower();
            return sb.ToString();

        }

    }
}
