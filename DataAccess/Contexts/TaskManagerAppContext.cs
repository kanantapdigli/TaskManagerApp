using Core.Entities;
using DataAccess.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class TaskManagerAppContext : IdentityDbContext<User, Role, string>
    {
        public TaskManagerAppContext(DbContextOptions<TaskManagerAppContext> options)
            :base(options)
        {

        }

        #region Entities

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Staff> Staffs { get; set; }


        #endregion

        #region Configurations

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AssignmentConfiguration());
            builder.ApplyConfiguration(new OrganizationConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new StaffConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }

        #endregion
    }
}
