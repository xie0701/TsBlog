using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public bool ChangePassword(string loginName, string newPassword)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var result = db.Updateable<User>().SetColumns(it => new User() { Password = newPassword, ModifiedOn = DateTime.Now }).Where(it => it.LoginName == loginName).ExecuteCommand();
                return result > 0;
            }
        }
    }
}
