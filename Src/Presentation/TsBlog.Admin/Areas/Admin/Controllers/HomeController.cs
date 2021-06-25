using System;
using System.Web.Mvc;
using TsBlog.Admin.Models;
using TsBlog.Core;
using TsBlog.Core.Model;
using TsBlog.Core.Operator;
using TsBlog.Domain.Entities;
using TsBlog.Services;

namespace TsBlog.Admin.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuService _menuService;
        public HomeController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        //
        // GET: /Admin/Home/
        public  ActionResult Index()
        {
            var operatorInfo = OperatorProvider.Provider.GetCurrent();
            return View(operatorInfo);
        }

        //
        // GET: /Admin/Home/Console/
        public ActionResult Console()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMenuInfo()
        {
            var menuList = _menuService.GetMenuListByRoleId(OperatorProvider.Provider.GetCurrent().RoleId);
            return Json(menuList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetServerInfo()
        {
            TData<ServerInfo> obj = new TData<ServerInfo>();
            ServerInfo serverInfo = new ServerInfo();
            serverInfo.ServerName = Environment.MachineName; // 服务器名称
            serverInfo.OperatingSystem = NetHelper.GetOSVersion();  //操作系统
            serverInfo.ProcessorCount = Environment.ProcessorCount; // CPU核心数
            serverInfo.StartDate = DateTime.Now.AddMilliseconds(-Environment.TickCount).ToString("yyyy-MM-dd HH:mm");   //启动日期

            serverInfo.IpLocation = "China";
            serverInfo.LanIP = NetHelper.GetLanIp(); // 局域网IP
            serverInfo.PublicIP = "113.88.238.133";

            if (Environment.Is64BitOperatingSystem)
                serverInfo.SystemFramework = "X64";
            else
                serverInfo.SystemFramework = "X32";

            serverInfo.FrameworkVersion = Environment.Version.Major.ToString() + '.' + Environment.Version.MajorRevision.ToString();
            serverInfo.RamUse = ((Double)System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / 1048576).ToString("N2") + " MB";
            serverInfo.StartTime = System.Diagnostics.Process.GetCurrentProcess().StartTime.ToString("yyyy-MM-dd HH:mm");
            obj.Data = serverInfo;
            obj.Code = 1;
            obj.Message = "OK";

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
	}
}