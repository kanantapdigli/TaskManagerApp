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
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        Task<IdentityResult> CreateAsync(Staff staff, string password);
        Task<IdentityResult> AddToRoleAsync(Staff staff, string role);
        Task<List<Staff>> GetAllByOrganizationAsync(int organizationId);
        Task<bool> CheckPasswordAsync(Staff staff, string password);
        Task<IdentityResult> ResetPasswordAsync(Staff staff, string newPassword);
        Task<IdentityResult> UpdateWithResultAsync(Staff staff);
        Task<Staff> FindByEmailAsync(string email);
        Task<Staff> GetStaffWithOrganizationAsync(ClaimsPrincipal User);
        Task<Staff> GetUserAsync(ClaimsPrincipal User);
    }
}
