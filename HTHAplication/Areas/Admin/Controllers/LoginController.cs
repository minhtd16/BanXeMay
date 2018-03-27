using HTHAplication.Areas.Admin.Models;
using HTHApplication;
using HTHApplication.Areas.Admin.Models;
using HTHApplication.Common;
using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var hashpass = new SaltedPassword();
                var user = dao.GetByUsername(model.UserName);
                if (user != null)
                {
                    var result = dao.Login(model.UserName, hashpass.EncodePassword(model.Password, user.SaltPass));
                    if (result == 1)
                    {
                        var userSession = new UserLogin();
                        userSession.UserName = user.UserName;
                        userSession.UserId = user.ID;
                        userSession.GroupID = user.GroupID;
                       
                        Session["UserName"] = user.UserName;
                        var listCredentials = dao.GetListCredential(model.UserName);

                        Session.Add(CommonFunction.SESSION_CREDENTIALS, listCredentials);
                        Session.Add(CommonFunction.USER_SESSION, userSession);

                        return RedirectToAction("Index", "Home");
                    }
                    else if (result == -1)
                    {
                        ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập không đúng!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }

            }
            return View("Index");

        }
        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePass(PasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.NewPassword != model.RepeatPassword)
                {
                    ModelState.AddModelError("", "Mật khẩu mới không trùng khớp!");
                }
                else
                {
                    var dao = new UserDao();
                    string userName = Session["UserName"].ToString();
                    var user = dao.GetByUsername(userName);
                    var hashpass = new SaltedPassword();
                    int result = dao.ChangePass(userName, hashpass.EncodePassword(model.OldPassword, user.SaltPass), hashpass.EncodePassword(model.RepeatPassword, user.SaltPass));
                    if (result == 1)
                    {

                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mật khẩu đăng nhập sai!");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thất bại, vui lòng liên hệ với quản trị viên!");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Index");
        }
    }
}