using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TsBlog.Admin.Areas.Permission.Models
{
    public class DataResult
    {
        public const string SUCCESS = "操作成功";
        public const string ERROR = "操作失败";

        public string msg { get; set; }
        public int code { get; set; }
        public int count { get; set; }
        public string tip { get; set; }
    }

    public class DataResult<T> : DataResult
    {
        public T data { get; set; }
    }
}