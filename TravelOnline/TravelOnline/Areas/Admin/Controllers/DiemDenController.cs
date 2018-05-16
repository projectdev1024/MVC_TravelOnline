using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Areas.Admin.Controllers
{
    public class DiemDenController : BaseController
    {
        //
        // GET: /Admin/DiemDen/

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new DiemDenDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblDIEMDEN diadiem)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiemDenDAO();
                long id = dao.Insert(diadiem);
                if (id > 0)
                {
                    return RedirectToAction("Index", "DiemDen");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm điểm đến không thành công");
                }
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var diadiem = new DiemDenDAO().ViewDetail(id);
            return View(diadiem);
        }

        [HttpPost]
        public ActionResult Edit(tblDIEMDEN diadiem)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiemDenDAO();
                var result = dao.Update(diadiem);
                if (result)
                {
                    return RedirectToAction("Index", "DiemDen");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa địa điểm không thành công");
                }
            }
            return View("Edit");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new DiemDenDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
