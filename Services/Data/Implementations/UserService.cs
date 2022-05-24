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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _unitOfWork.Users.GetAsync(id);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _unitOfWork.Users.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return await _unitOfWork.Users.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            return await _unitOfWork.Users.CreateAsync(user, password);
        }

        public async Task UpdateAsync(User user)
        {
            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(User user)
        {
            await _unitOfWork.Users.DeleteAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal User)
        {
            return await _unitOfWork.Users.GetUserAsync(User);
        }

        public async Task<User> GetUserWithOrganizationAsync(ClaimsPrincipal User)
        {
            return await _unitOfWork.Users.GetUserWithOrganizationAsync(User);
        }
    }
}
