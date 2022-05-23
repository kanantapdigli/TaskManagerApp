using Core.DataAccess;
using Core.DataAccess.Abstractions;
using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private TaskManagerAppContext _context;
        private readonly UserManager<User> _userManager;
        private readonly UserManager<Staff> _staffManager;
        private readonly RoleManager<Role> _roleManager;

        public UnitOfWork(TaskManagerAppContext context, 
            UserManager<User> userManager,
            UserManager<Staff> staffManager,
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _staffManager = staffManager;
            _roleManager = roleManager;
        }

        private IAssignmentRepository assignment;
        public IAssignmentRepository Assignments => assignment ??= new AssignmentRepository(_context);

        private IRoleRepository role;
        public IRoleRepository Roles => role ??= new RoleRepository(_context, _roleManager);

        private IUserRepository user;
        public IUserRepository Users => user ??= new UserRepository(_context, _userManager);

        private IOrganizationRepository organization;
        public IOrganizationRepository Organizations => organization ??= new OrganizationRepository(_context);

        private IStaffRepository staff;
        public IStaffRepository Staffs => staff ??= new StaffRepository(_context, _staffManager);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
