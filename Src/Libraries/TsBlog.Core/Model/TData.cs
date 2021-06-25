using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Core.Model
{
    public class TData
    {
        public int Code { get; set; }

        public object State { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }
    }

    public class TData<T> : TData
    {
        public int Count { get; set; }

        public T Data { get; set; }
    }

    public enum ResultType
    {
        /// <summary>
        /// 消息结果类型
        /// </summary>
        INFO,
        /// <summary>
        /// 成功结果类型
        /// </summary>
        SUCCESS,
        /// <summary>
        /// 警告结果类型
        /// </summary>
        WARN,
        /// <summary>
        /// 错误结果类型
        /// </summary>
        ERROR
    }
}
