using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstractions
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<IdentityResult> CreateWithResultAsync(Role role);
    }
}
