using Core.DataAccess;
using Core.Entities;
using Core.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            return await _unitOfWork.Staffs.GetAllAsync();
        }

        public async Task<Staff> GetAsync(string id)
        {
            return await _unitOfWork.Staffs.GetAsync(id);
        }

        public async Task CreateAsync(Staff staff)
        {
            await _unitOfWork.Staffs.CreateAsync(staff);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Staff staff)
        {
            await _unitOfWork.Staffs.UpdateAsync(staff);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Staff staff)
        {
            await _unitOfWork.Staffs.DeleteAsync(staff);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IdentityResult> CreateAsync(Staff staff, string password)
        {
            return await _unitOfWork.Staffs.CreateAsync(staff, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(Staff staff, string role)
        {
            return await _unitOfWork.Staffs.AddToRoleAsync(staff, role);
        }

        public async Task<List<Staff>> GetAllByOrganizationAsync(int organizationId)
        {
            return await _unitOfWork.Staffs.GetAllByOrganizationAsync(organizationId);
        }

        public async Task<bool> CheckPasswordAsync(Staff staff, string password)
        {
            return await _unitOfWork.Staffs.CheckPasswordAsync(staff, password);
        }

        public async Task<IdentityResult> ResetPasswordAsync(Staff staff, string newPassword)
        {
            return await _unitOfWork.Staffs.ResetPasswordAsync(staff, newPassword);
        }

        public async Task<IdentityResult> UpdateWithResultAsync(Staff staff)
        {
            return await _unitOfWork.Staffs.UpdateWithResultAsync(staff);
        }

        public async Task<Staff> FindByEmailAsync(string email)
        {
            return await _unitOfWork.Staffs.FindByEmailAsync(email);
        }

        public async Task<Staff> GetStaffWithOrganizationAsync(ClaimsPrincipal User)
        {
            return await _unitOfWork.Staffs.GetStaffWithOrganizationAsync(User);
        }
    }
}
