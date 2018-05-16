using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Areas.Admin.Controllers
{
    public class TourController : BaseController
    {
        //
        // GET: /Admin/Tour/

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new TourDAO();
            var model = dao.ListAllPaging(page, pageSize);
            //ViewBag.madd = new DiemDenDAO().GetDiemDen();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblTOUR tour)
        {
            if (ModelState.IsValid)
            {
                var dao = new TourDAO();
                long id = dao.Insert(tour); 
               
                if (id > 0)
                {
                    return RedirectToAction("Index", "Tour");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tour không thành công");
                }
            }
            SetViewBag();
            return View("Create");
        }

        public void SetViewBag(int? selectedId = null)
        {
            var dao = new DiemDenDAO();
            ViewBag.madd = new SelectList(dao.ListAll(), "madd", "diemden", selectedId);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tour = new TourDAO().ViewDetail(id);
            SetViewBag(tour.madd);
            return View(tour);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new TourDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(tblTOUR tour)
        {
            if (ModelState.IsValid)
            {
                var dao = new TourDAO();
                var result = dao.Update(tour);
                if (result)
                {
                    return RedirectToAction("Index", "Tour");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa tour không thành công");
                }
            }
            return View("Edit");
        }

        public ActionResult LichKhoiHanh()
        {
            var tourDAO = new TourDAO();
            var model = tourDAO.GetTourGanDay(10);
            return View(model);
        }
    }
}
