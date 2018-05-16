using Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelOnline.Areas.Admin.Code;
using TravelOnline.Areas.Admin.Models;
using TravelOnline.Common;


namespace TravelOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/

        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName,Encryptor.MD5Hash(model.PassWord));
                if (result== 1)
                {
                    var userSession = new UserLogin();
                    var user = dao.GetByID(model.UserName);
                    userSession.UserID = user.id;
                    userSession.UserName = user.taikhoan;
                    Session.Add(CommonConstants.USER_SESSION,userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (result == -2)
                        ModelState.AddModelError("", "Mật khẩu không đúng");
                    else
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
            }
            return View("Index");
        }
      

    }
}
