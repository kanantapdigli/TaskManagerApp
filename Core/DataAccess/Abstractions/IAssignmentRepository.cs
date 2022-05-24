using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstractions
{
    public interface IAssignmentRepository : IBaseRepository<Assignment>
    {
        Task<List<Assignment>> GetAllByDescendingAsync();

        Task<List<Assignment>> GetAllByDescendingWithStaffsAsync();

        Task<List<string>> GetStaffIdsAsync(int assignmentId);

        Task<Assignment> GetWithStaffsAsync(int assignmentId);

        Task<List<Assignment>> GetAllByOrganizationWithStaffsAsync(int organizationId);
    }
}
