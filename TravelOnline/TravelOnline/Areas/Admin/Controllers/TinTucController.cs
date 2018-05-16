using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;

namespace TravelOnline.Areas.Admin.Controllers
{
    public class TinTucController : BaseController
    {
        //
        // GET: /Admin/TinTuc/

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new TinTucDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblTINTUC tintuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDAO();
                long id = dao.Insert(tintuc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "TinTuc");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tin tức không thành công");
                }
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tintuc = new TinTucDAO().ViewDetail(id);
            return View(tintuc);
        }

        [HttpPost]
        public ActionResult Edit(tblTINTUC tintuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDAO();
                var result = dao.Update(tintuc);
                if (result)
                {
                    return RedirectToAction("Index", "TinTuc");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa tin không thành công");
                }
            }
            return View("Edit");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new TinTucDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
