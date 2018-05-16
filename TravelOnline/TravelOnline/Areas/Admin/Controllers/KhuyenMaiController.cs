using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Areas.Admin.Controllers
{
    public class KhuyenMaiController : BaseController
    {
        //
        // GET: /Admin/KhuyenMai/

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new KhuyenMaiDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        public void SetViewBag(int? selectedId = null)
        {
            var dao = new TourDAO();
            ViewBag.matour = new SelectList(dao.TourChuaKhuyenMai(), "matour", "tentour", selectedId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblKHUYENMAI khuyenmai)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhuyenMaiDAO();
                long id = dao.Insert(khuyenmai);
                if (id > 0)
                {
                    return RedirectToAction("Index", "KhuyenMai");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tour không thành công");
                }
            }
            SetViewBag();
            return View("Create");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new KhuyenMaiDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var khuyenmai = new KhuyenMaiDAO().ViewDetail(id);
            SetViewBag(khuyenmai.matour);
            return View(khuyenmai);
        }

        [HttpPost]
        public ActionResult Edit(tblKHUYENMAI khuyenmai)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhuyenMaiDAO();
                var result = dao.Update(khuyenmai);
                if (result)
                {
                    return RedirectToAction("Index", "KhuyenMai");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa khuyến mại không thành công");
                }
            }
            return View("Edit");
        }

    }
}
