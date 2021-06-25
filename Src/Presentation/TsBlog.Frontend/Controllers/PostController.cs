using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig;
using TsBlog.Services;

namespace TsBlog.Frontend.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        //
        // GET: /Post/
        public ActionResult Details(int id)
        {
            var post = _postService.FindById(id);
            var model = post.ToModel();
            return View(model);
        }
	}
}