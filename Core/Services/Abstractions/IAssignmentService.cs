using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstractions
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAllAsync();
        Task<List<Assignment>> GetAllByOrderDescendingAsync();
        Task<Assignment> GetAsync(int id);
        Task CreateAsync(Assignment assignment);
        Task UpdateAsync(Assignment assignment);
        Task DeleteAsync(Assignment assignment);
        Task<List<Assignment>> GetAllByDescendingWithStaffsAsync();
        Task<List<string>> GetStaffIdsAsync(int assignmentId);
        Task<Assignment> GetWithStaffsAsync(int assignmentId);
    }
}
