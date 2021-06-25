using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Core.Security;

namespace TsBlog.Core.Operator
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }

        private string LoginUserKey = "audience";
        private string LoginProvider = "Cookie";

        public OperatorInfo GetCurrent()
        {
            OperatorInfo operatorModel = new OperatorInfo();
            if (LoginProvider == "Cookie")
                operatorModel = Encryptor.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorInfo>();
            else
                operatorModel = Encryptor.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorInfo>();
            return operatorModel;
        }

        public void AddCurrent(OperatorInfo operatorModel)
        {
            if (LoginProvider == "Cookie")
                WebHelper.WriteCookie(LoginUserKey, Encryptor.Encrypt(operatorModel.ToJson()), 60);
            else
                WebHelper.WriteSession(LoginUserKey, operatorModel.ToJson());
        }

        public void RemoveCurrent()
        {
            if (LoginProvider == "Cookie")
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            else
                WebHelper.RemoveSession(LoginUserKey.Trim());
        }
    }
}
