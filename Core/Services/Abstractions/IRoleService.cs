using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstractions
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllAsync();
        Task<Role> GetAsync(int id);
        Task CreateAsync(Role role);
        Task<IdentityResult> CreateWithResultAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(Role role);
    }
}
