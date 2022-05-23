using Core.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IUnitOfWork
    {
        IAssignmentRepository Assignments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IOrganizationRepository Organizations { get; }
        IStaffRepository Staffs { get; }


        Task CommitAsync();
    }
}
