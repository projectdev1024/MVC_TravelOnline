using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;
using TravelOnline.Common;
using System.Globalization;
using PagedList;

namespace TravelOnline.Areas.Admin.Controllers
{
    public class KhachHangController : BaseController
    {
        //
        // GET: /Admin/KhachHang/

        public ActionResult Index(string searchString,int page = 1, int pageSize = 10)
        {
            var dao = new KhachHangDAO();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblKHACHHANG khachhang)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDAO();
                if (string.IsNullOrEmpty(khachhang.matkhau))
                {
                    ModelState.AddModelError("", "Bạn chưa nhập mật khẩu");
                }
                else
                {
                    var encrytedMd5Pas = Encryptor.MD5Hash(khachhang.matkhau);
                    khachhang.matkhau = encrytedMd5Pas;
                    if (dao.kiemTraTaiKhoan(khachhang.taikhoan) == 0)
                    {
                        long id = dao.Insert(khachhang);
                        if (id > 0)
                        {
                            return RedirectToAction("Index", "KhachHang");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Thêm khách hàng không thành công");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tài khoản đã tồn tại");
                    }
                }
            }
            return View("Create");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var khachHang = new KhachHangDAO().ViewDetail(id);
            return View(khachHang);
        }

        [HttpPost]
        public ActionResult Edit(tblKHACHHANG khachhang)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDAO();
                if (!string.IsNullOrEmpty(khachhang.matkhau))
                {
                    var encrytedMd5Pas = Encryptor.MD5Hash(khachhang.matkhau);
                    khachhang.matkhau = encrytedMd5Pas;
                }
                var result = dao.Update(khachhang);
                if (result)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khách hàng không thành công");
                }
            }
            return View("Edit");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new KhachHangDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
