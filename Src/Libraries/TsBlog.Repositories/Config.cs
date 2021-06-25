using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TsBlog.Repositories
{
    public class Config
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["TsBlogMySQLDb"].ConnectionString;

        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}
