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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly TaskManagerAppContext _db;
        private readonly UserManager<User> _userManager;

        public UserRepository(TaskManagerAppContext db, 
            UserManager<User> userManager) : base(db) 
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal User)
        {
            return await _userManager.GetUserAsync(User);
        }

        public async Task<User> GetUserWithOrganizationAsync(ClaimsPrincipal User)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return null;

            return _db.Users
                            .Include(u => u.Organization)
                            .FirstOrDefault(u => u.Id == user.Id);
        }
    }
}
