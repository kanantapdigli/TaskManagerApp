using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IdentityResult> CreateAsync(User user, string password);

        Task<User> FindByEmailAsync(string email);

        Task<IdentityResult> AddToRoleAsync(User user, string role);

        Task<User> GetUserAsync(ClaimsPrincipal User);

        Task<User> GetUserWithOrganizationAsync(ClaimsPrincipal User);
    }
}
