using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.Core;
using TsBlog.Core.Security;
using TsBlog.Domain.Entities;
using TsBlog.Services;
using TsBlog.ViewModel.User;

namespace TsBlog.Frontend.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CreateValidCode()
        {
            var strRandom = ValidCodeUtils.GetRandomCode(5);
            byte[] byteImg = ValidCodeUtils.CreateImage(strRandom);
            Session["ValidCode"] = strRandom;
            return File(byteImg, @"image/jpeg");
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string sessionVaildCode = Session["ValidCode"] == null ? "" : Session["ValidCode"].ToString();
            if (!sessionVaildCode.Equals(model.ValidCode, StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("error_message", "验证码错误");
                return View(model);
            }
                
            var user = _userService.FindByLoginName(model.UserName.Trim());
            if (user == null)
            {
                ModelState.AddModelError("error_message", "用户不存在");
                return View(model);
            }

            if (user.Password != Encryptor.Md5Hash(model.Password.Trim()))
            {
                ModelState.AddModelError("error_message", "密码错误,请重新登录");
                return View(model);
            }


            Session["user_account"] = user;

            return RedirectToAction("index", "home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                LoginName = model.UserName,
                Password = Encryptor.Md5Hash(model.Password.Trim()),
                CreatedOn = DateTime.Now
            };

            var ret = _userService.Insert(user);
            if (ret <= 0)
            {
                ModelState.AddModelError("error_message", "注册失败");
                return View(model);
            }

            return RedirectToAction("login");
        }
	}
}