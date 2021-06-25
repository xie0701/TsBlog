using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public class RoleService : GenericService<Role>, IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public List<Role> GetRoleList()
        {
            return _repository.FindAll().ToList();
        }
    }
}
