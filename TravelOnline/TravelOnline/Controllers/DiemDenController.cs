using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOnline.Controllers
{
    public class DiemDenController : Controller
    {
        //
        // GET: /DiemDen/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetDiemDen(int id)
        {
            var quangcaoDAO = new QuangCaoDAO();
            ViewBag.QuangCao = quangcaoDAO.DanhSachQuangCao();
            var result = new DiemDenDAO().Seach(id);
            JsonResult json = new JsonResult();
            json.Data = result;
            return json;
        }

        //public ActionResult Search(int diemden, int giatour, string khoihanh, int page = 1, int pageSize = 3)
        //{
        //    var dao = new TourDAO();
        //    var model = dao.SearchTour(diemden, giatour, khoihanh,page,pageSize);
        //    return View(model);
        //}

    }
}
