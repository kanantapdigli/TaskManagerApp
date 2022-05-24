using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<User> FindByEmailAsync(string email);
        Task<User> GetUserAsync(ClaimsPrincipal User);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        Task<User> GetUserWithOrganizationAsync(ClaimsPrincipal User);
    }
}
