using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TsBlog.ViewModel.Post;
using TsBlog.Core;

namespace TsBlog.Frontend.Extensions
{
    public static class PostExtension
    {
        public static PostViewModel FormatPostViewModel(this PostViewModel model)
        {
            if (model == null) return null;
            model.Summary = model.Content.CleanHtml().TruncateString(200, StringHelper.TruncateOptions.FindshWord | StringHelper.TruncateOptions.AllowLastWordToGoOverMaxLength);
            return model;
        }
    }
}