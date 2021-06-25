using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Core
{
    public static class StringHelper
    {
        public static string CutStrLength(this string str, int strLength)
        {
            var strNew = str;
            if (string.IsNullOrEmpty(strNew)) return strNew;
            var strOriginalLength = strNew.Length;
            if (strOriginalLength > strLength)
            {
                strNew = strNew.Substring(0, strLength) + "...";
            }
            return strNew;
        }

        public static string CutStrLength(string str, int strLength, bool endWithEllipsis)
        {
            string strNew = str;
            if (!strNew.Equals(""))
            {
                int strOriginalLength = strNew.Length;
                if (strOriginalLength > strLength)
                {
                    strNew = strNew.Substring(0, strLength);
                    if (endWithEllipsis)
                    {
                        strNew += "...";
                    }
                }
            }
            return strNew;
        }

        public static string TruncateString(this string valueToTruncate, int maxLength, TruncateOptions options)
        {
            if (valueToTruncate == null) return "";
            if (valueToTruncate.Length <= maxLength) return valueToTruncate;
            var includeEllipsis = (options & TruncateOptions.IncludeEllipsis) == TruncateOptions.IncludeEllipsis;
            var finishWord = (options & TruncateOptions.FindshWord) == TruncateOptions.FindshWord;
            var allowLastWordOverflow = (options & TruncateOptions.AllowLastWordToGoOverMaxLength) == TruncateOptions.AllowLastWordToGoOverMaxLength;

            var retValue = valueToTruncate;

            if (includeEllipsis) maxLength -= 1;

            var lastSpaceIndex = retValue.LastIndexOf(" ", maxLength, StringComparison.CurrentCultureIgnoreCase);

            if (!finishWord) { retValue = retValue.Remove(maxLength); }
            else if (allowLastWordOverflow)
            {
                var spaceIndex = retValue.IndexOf(" ", maxLength, StringComparison.CurrentCultureIgnoreCase);
                if (spaceIndex != -1)
                {
                    retValue = retValue.Remove(spaceIndex);
                }
            }
            else if (lastSpaceIndex > -1)
            {
                retValue = retValue.Remove(lastSpaceIndex);
            }

            if (includeEllipsis && retValue.Length < valueToTruncate.Length)
            {
                retValue += "...";
            }
            return retValue;
        }

        public enum TruncateOptions
        {
            /// <summary>
            /// 不作任何处理
            /// </summary>
            None = 0x0,

            /// <summary>
            /// 保留完整单词
            /// </summary>
            FindshWord = 0x1,

            /// <summary>
            /// 允许最后一个单词超过最大长度限制
            /// </summary>
            AllowLastWordToGoOverMaxLength = 0x2,

            /// <summary>
            /// 字符串最后跟省略号
            /// </summary>
            IncludeEllipsis = 0x4
        }
    }
}
