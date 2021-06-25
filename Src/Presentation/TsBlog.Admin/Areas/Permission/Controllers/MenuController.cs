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
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        //
        // GET: /Permission/Menu/
        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Action", Value = "0" });

            items.Add(new SelectListItem { Text = "Drama", Value = "1" });

            items.Add(new SelectListItem { Text = "Comedy", Value = "2", Selected = true });

            items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

            ViewData["MenuStatus"] = items;
            return View();
        }

        [HttpPost]
        public JsonResult GetMenuList()
        {
            var list = _menuService.GetMenuList();
            DataResult<object> result = new DataResult<object>();
            result.code = 0;
            result.data = list;
            result.count = list.Count;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(Menu menu)
        {
            menu.CreateOn = DateTime.Now;
            DataResult result = new DataResult();
            if (_menuService.Insert(menu) > 0)
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

        public ActionResult Edit(int? id)
        {
            var menu = _menuService.FindById(id);
            return View(menu);
        }

        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            menu.UpdateOn = DateTime.Now;
            DataResult result = new DataResult();
            if (_menuService.Update(menu, m=>m.CreateOn))
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

        public ActionResult Delete(int? id)
        {
            DataResult result = new DataResult();
            if (_menuService.DeleteById(id))
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

        [HttpGet]
        public JsonResult GetTopMenu()
        {
            var list = _menuService.GetTopMenu();
            DataResult<object> result = new DataResult<object>();
            result.count = 1;
            result.data = list;
            result.count = list.Count();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}