using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Areas.Admin.Controllers
{
    public class QuangCaoController : BaseController
    {
        //
        // GET: /Admin/QuangCao/

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new QuangCaoDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblQUANGCAO model)
        {
            if (ModelState.IsValid)
            {
                var dao = new QuangCaoDAO();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "QuangCao");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm quảng cáo không thành công");
                }
            }
            return View("Create");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new QuangCaoDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var qc = new QuangCaoDAO().ViewDetail(id);
            return View(qc);
        }

        [HttpPost]
        public ActionResult Edit(tblQUANGCAO qc)
        {
            if (ModelState.IsValid)
            {
                var dao = new QuangCaoDAO();
                var result = dao.Update(qc);
                if (result)
                {
                    return RedirectToAction("Index", "QuangCao");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa quảng cáo không thành công");
                }
            }
            return View("Edit");
        }
    }
}
