using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TsBlog.Core
{
    public static class HtmlHelper
    {
        public static string CleanHtml(this string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml)) return strHtml;

            strHtml = Regex.Replace(strHtml, "(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var r = new Regex(@"<\/?[^>]*>", RegexOptions.IgnoreCase);
            Match m;
            for (m = r.Match(strHtml); m.Success; m = m.NextMatch())
            {
                strHtml = strHtml.Replace(m.Groups[0].ToString(), "");
            }
            return strHtml.Trim();
        }

        public static string Resove(string html, string prefix, string subfix)
        {
            int inl = html.IndexOf(prefix);
            if (inl == -1)
            {
                return null;
            }
            inl += prefix.Length;
            int inl2 = html.IndexOf(subfix, inl);
            string s = html.Substring(inl, inl2 - inl);
            return s;
        }

        public static string ResoveReverse(string html, string subfix, string prefix)
        {
            int inl = html.IndexOf(subfix);
            if (inl == -1)
            {
                return null;
            }
            string subString = html.Substring(0, inl);
            int inl2 = subString.LastIndexOf(prefix);
            if (inl2 == -1)
            {
                return null;
            }
            string s = subString.Substring(inl2 + prefix.Length, subString.Length - inl2 - prefix.Length);
            return s;
        }

        public static List<string> ResoveList(string html, string prefix, string subfix)
        {
            List<string> list = new List<string>();
            int index = prefix.Length * -1;
            do
            {
                index = html.IndexOf(prefix, index + prefix.Length);
                if (index == -1)
                {
                    break;
                }
                index += prefix.Length;
                int index4 = html.IndexOf(subfix, index);
                string s78 = html.Substring(index, index4 - index);
                list.Add(s78);
            }
            while (index > -1);
            return list;
        }
    }
}
