using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;

namespace TsBlog.Services
{
    public interface IRoleService : IService<Role>
    {
        List<Role> GetRoleList(string roleName);
    }
}
