using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.ViewModel.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string CreatedAt { get; set; }

        public string PublishedAt { get; set; }

        public string IsDeleted { get; set; }

        public bool AllowShow { get; set; }

        public int ViewCount { get; set; }

        public string Summary { get; set; }
    }
}
