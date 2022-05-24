using Core.DataAccess;
using Core.Entities;
using Core.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _unitOfWork.Roles.GetAllAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await _unitOfWork.Roles.GetAsync(id);
        }

        public async Task CreateAsync(Role role)
        {
            await _unitOfWork.Roles.CreateAsync(role);
        }

        public async Task UpdateAsync(Role role)
        {
            await _unitOfWork.Roles.UpdateAsync(role);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            await _unitOfWork.Roles.DeleteAsync(role);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IdentityResult> CreateWithResultAsync(Role role)
        {
            return await _unitOfWork.Roles.CreateWithResultAsync(role);
        }
    }
}
