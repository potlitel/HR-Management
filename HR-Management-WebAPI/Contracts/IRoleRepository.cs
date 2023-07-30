using HR_Management_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Contracts
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRoles();
        Task<int> CreateRole(Role role);
    }
}
