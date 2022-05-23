using Core.Constants.User;
using Core.Entities;
using Core.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataSeeder
    {
        public static void SeedRoles(IRoleService _roleService)
        {
            var dbRoles = _roleService.GetAllAsync().Result;
            var roles = Enum.GetValues<Roles>();

            foreach (var role in roles)
            {
                if (!dbRoles.Any(r => r.Name == role.ToString()))
                {
                    _ = _roleService.CreateWithResultAsync(new Role { Name = role.ToString() }).Result;
                }
            }
        }
    }
}
