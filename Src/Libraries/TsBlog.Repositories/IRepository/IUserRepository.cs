using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool ChangePassword(string loginName, string newPassword);
    }
}
