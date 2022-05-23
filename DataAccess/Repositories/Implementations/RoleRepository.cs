using Core.DataAccess.Abstractions;
using Core.Entities;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleRepository(TaskManagerAppContext db,
            RoleManager<Role> roleManager) : base(db)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateWithResultAsync(Role role)
        {
            return await _roleManager.CreateAsync(role);
        }
    }
}
