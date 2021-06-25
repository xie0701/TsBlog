using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.Core.Model;
using TsBlog.Core.Operator;

namespace TsBlog.Admin.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected const string SUCCESS_TEXT = "操作成功！";
        protected const string ERROR_TEXT = "操作失败！";

        public OperatorInfo Operator
        {
            get
            {
                return OperatorProvider.Provider.GetCurrent();
            }
        }
        //
        // GET: /Admin/Base/
        public virtual ActionResult Index(int? id)
        {
            var _menuId = id == null ? 0 : id.Value;
            var _roleId = Operator.RoleId;
            if (id != null)
            {
                ViewData["ActionList"] = "";
                ViewData["ActionFormRightTop"] = "";
            }
            return View();
        }

        protected virtual TData SuccessTip(string message = SUCCESS_TEXT)
        {
            return new TData { State = ResultType.SUCCESS.ToString(), Message = message };
        }

        protected virtual TData ErrorTip(string message = ERROR_TEXT)
        {
            return new TData { State = ResultType.ERROR.ToString(), Message = message };
        }
	}
}