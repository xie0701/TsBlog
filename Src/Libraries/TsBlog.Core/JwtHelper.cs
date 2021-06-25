using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Core.Operator;

namespace TsBlog.Core
{
    public class JwtHelper
    {
        private static string secret = ConfigurationManager.AppSettings["Secret"].ToString();
        private static string issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        private static string audience = ConfigurationManager.AppSettings["Audience"].ToString();
        private static double expiationTime = Double.Parse(ConfigurationManager.AppSettings["ExpirationTime"]);

        public static string SetJwtEncode(OperatorInfo operatorInfo)
        {
            var provider = new UtcDateTimeProvider();
            var now = provider.GetNow();
            var expiration = UnixEpoch.GetSecondsSince(now.AddMinutes(expiationTime));

            var payload = new Dictionary<string, object>()
            {
                {"UserId", operatorInfo.UserId},
                {"UserName", operatorInfo.UserName},
                {"iss", issuer},
                {"aud", audience},
                {"exp", expiration},
                {"iat", now}
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, secret);
            return token;
        }

        public static string GetJwtDecode(string token)
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            var provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
            var obj = decoder.Decode(token, secret, verify: true);
            return obj;
        }
    }
}
