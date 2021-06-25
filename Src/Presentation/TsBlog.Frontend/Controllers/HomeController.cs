using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.Repositories;
using TsBlog.Services;
using TsBlog.AutoMapperConfig;
using TsBlog.Frontend.Extensions;
using PagedList;
using TsBlog.ViewModel.Post;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public ActionResult Index(int? page)
        {
            if (Session["user_account"] == null)
            {
                return RedirectToAction("login", "account");
            }

            page = page ?? 1;
            var pageList = _postService.FindHomePagePosts(20);
            var list = _postService.FindPagedList(x => !x.IsDeleted && x.AllowShow, pageIndex: (int)page, pageSize: 10);
            var model = list.Select(x => x.ToModel().FormatPostViewModel());
            ViewBag.Pagination = new StaticPagedList<PostViewModel>(model, list.PageIndex, list.PageSize, list.TotalCount);
            return View(model);

        }
    }
}