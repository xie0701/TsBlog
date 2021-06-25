using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TsBlog.Core.Security
{
    /// <summary>
    /// 加密静态类
    /// </summary>
    public static class Encryptor
    {
        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Md5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            var result = md5.Hash;

            var strBuilder = new StringBuilder();
            foreach (var t in result)
            {
                strBuilder.Append(t.ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}
