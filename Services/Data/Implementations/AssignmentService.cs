using Core.DataAccess;
using Core.Entities;
using Core.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Assignment>> GetAllAsync()
        {
            return await _unitOfWork.Assignments.GetAllAsync();
        }

        public async Task<List<Assignment>> GetAllByOrderDescendingAsync()
        {
            return await _unitOfWork.Assignments.GetAllByDescendingAsync();
        }

        public async Task<Assignment> GetAsync(int id)
        {
            return await _unitOfWork.Assignments.GetAsync(id);
        }

        public async Task CreateAsync(Assignment assignment)
        {
            await _unitOfWork.Assignments.CreateAsync(assignment);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Assignment assignment)
        {
            await _unitOfWork.Assignments.UpdateAsync(assignment);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Assignment assignment)
        {
            await _unitOfWork.Assignments.DeleteAsync(assignment);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Assignment>> GetAllByDescendingWithStaffsAsync()
        {
            return await _unitOfWork.Assignments.GetAllByDescendingWithStaffsAsync();
        }

        public async Task<List<string>> GetStaffIdsAsync(int assignmentId)
        {
            return await _unitOfWork.Assignments.GetStaffIdsAsync(assignmentId);
        }

        public async Task<Assignment> GetWithStaffsAsync(int assignmentId)
        {
            return await _unitOfWork.Assignments.GetWithStaffsAsync(assignmentId);
        }

        public async Task<List<Assignment>> GetAllByOrganizationWithStaffsAsync(int organizationId)
        {
            return await _unitOfWork.Assignments.GetAllByOrganizationWithStaffsAsync(organizationId);
        }
    }
}
