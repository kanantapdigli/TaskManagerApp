using Core.DataAccess.Abstractions;
using Core.Entities;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        private readonly TaskManagerAppContext _db;
        private readonly UserManager<Staff> _staffManager;

        public StaffRepository(TaskManagerAppContext db,
            UserManager<Staff> staffManager) : base(db)
        {
            _db = db;
            _staffManager = staffManager;
        }

        public async Task<IdentityResult> AddToRoleAsync(Staff staff, string role)
        {
            return await _staffManager.AddToRoleAsync(staff, role);
        }

        public async Task<IdentityResult> ResetPasswordAsync(Staff staff, string newPassword)
        {
            var token = await _staffManager.GeneratePasswordResetTokenAsync(staff);
            return await _staffManager.ResetPasswordAsync(staff, token, newPassword);
        }

        public async Task<bool> CheckPasswordAsync(Staff staff, string password)
        {
            return await _staffManager.CheckPasswordAsync(staff, password);
        }


        public async Task<IdentityResult> CreateAsync(Staff staff, string password)
        {
           return await _staffManager.CreateAsync(staff, password);
        }

        public async Task<List<Staff>> GetAllByOrganizationAsync(int organizationId)
        {
            return await _db.Staffs
                                    .Where(s => s.OrganizationId == organizationId)
                                    .ToListAsync();
        }

        public async Task<IdentityResult> UpdateWithResultAsync(Staff staff)
        {
           return await _staffManager.UpdateAsync(staff);
        }

        public async Task<Staff> FindByEmailAsync(string email)
        {
            return await _staffManager.FindByEmailAsync(email);
        }

        public async Task<Staff> GetStaffWithOrganizationAsync(ClaimsPrincipal User)
        {
            var staff = await _staffManager.GetUserAsync(User);
            if (staff == null) return null;

            return await _db.Staffs
                            .Include(s => s.Organization)
                            .FirstOrDefaultAsync(s => s.Id == staff.Id);
        }

        public async Task<Staff> GetUserAsync(ClaimsPrincipal User)
        {
            return await _staffManager.GetUserAsync(User);
        }
    }
}
