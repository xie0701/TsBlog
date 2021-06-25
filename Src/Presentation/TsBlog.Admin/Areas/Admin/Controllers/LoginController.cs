using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TsBlog.Core;
using TsBlog.Core.Model;
using TsBlog.Core.Operator;
using TsBlog.Core.Security;
using TsBlog.Services;
using TsBlog.ViewModel.User;

namespace TsBlog.Admin.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        //
        // GET: /Admin/Login/
        public ActionResult Index()
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
        public ActionResult LoginCheck(LoginViewModel model)
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
            else
            {
                if (user.Password != Encryptor.Md5Hash(model.Password.Trim()))
                {
                    ModelState.AddModelError("error_message", "密码错误,请重新登录");
                    return View(model);
                }
                else
                {
                    OperatorInfo operatorInfo = new OperatorInfo();
                    operatorInfo.UserId = user.Id;
                    operatorInfo.UserName = user.LoginName;
                    operatorInfo.RoleId = user.RoleId;
                    operatorInfo.LoginIPAddress = NetHelper.GetLanIp();
                    operatorInfo.LoginIPAddressName = "China";
                    operatorInfo.LoginDate = DateTime.Now;
                    operatorInfo.LoginToken = Encryptor.Encrypt(Guid.NewGuid().ToString());
                    OperatorProvider.Provider.AddCurrent(operatorInfo);

                    string authToken = JwtHelper.SetJwtEncode(operatorInfo);
                    WebHelper.WriteCookie("authToken", authToken);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginOff()
        {
            SecurityBase.RemoveCookie();
            //Session["user_account"] = null;
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public JsonResult ResetPassword(ResetPasswordViewModel model)
        {
            var user = _userService.FindByLoginName(SecurityBase.UserName);
            TData result = new TData();
            if (user.Password == Encryptor.Md5Hash(model.OldPassword))
            {
                if (_userService.ChangePassword(user.LoginName, Encryptor.Md5Hash(model.NewPassword)))
                {
                    result.Code = 1;
                    result.Message = "修改成功";
                }
                else
                {
                    result.Code = -1;
                    result.Message = "修改失败";
                }
            }
            else
            {
                result.Code = 0;
                result.Message = "旧密码输入错误";
            }
            return Json(result);
        }
	}
}