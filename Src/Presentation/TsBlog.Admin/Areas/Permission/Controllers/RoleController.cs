using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.Admin.Areas.Permission.Models;
using TsBlog.Domain.Entities;
using TsBlog.Services;

namespace TsBlog.Admin.Areas.Permission.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        //
        // GET: /Permission/Role/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetRoleList(string? RoleName)
        {
            var roleList = _roleService.GetRoleList(RoleName);
            DataResult<object> result = new DataResult<object>();
            result.code = 0;
            result.data = roleList;
            result.count = roleList.Count;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Role role)
        {
            role.CreateOn = DateTime.Now;
            DataResult result = new DataResult();
            if (_roleService.Insert(role) > 0)
            {
                result.code = 1;
                result.tip = DataResult.SUCCESS;
            }
            else
            {
                result.code = 0;
                result.tip = DataResult.ERROR;
            }

            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            DataResult result = new DataResult();
            if (_roleService.DeleteById(id))
            {
                result.code = 1;
                result.tip = DataResult.SUCCESS;
            }
            else
            {
                result.code = 1;
                result.tip = DataResult.SUCCESS;
            }

            return Json(result);
        }

        public ActionResult Edit(int? id)
        {
            var role = _roleService.FindById(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(Role role)
        {
            role.UpdateOn = DateTime.Now;
            DataResult result = new DataResult();
            if (_roleService.Update(role, r => r.CreateOn))
            {
                result.code = 1;
                result.tip = DataResult.SUCCESS;
            }
            else
            {
                result.code = 0;
                result.tip = DataResult.ERROR;
            }

            return Json(result);
        }
	}
}