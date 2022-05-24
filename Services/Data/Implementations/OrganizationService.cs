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
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Organization>> GetAllAsync()
        {
            return await _unitOfWork.Organizations.GetAllAsync();
        }

        public async Task<Organization> GetAsync(int id)
        {
            return await _unitOfWork.Organizations.GetAsync(id);
        }

        public async Task CreateAsync(Organization organization)
        {
            await _unitOfWork.Organizations.CreateAsync(organization);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Organization organization)
        {
            await _unitOfWork.Organizations.UpdateAsync(organization);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Organization organization)
        {
            await _unitOfWork.Organizations.DeleteAsync(organization);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsStaffAsync(int organizationId, string staffId)
        {
            return await _unitOfWork.Organizations.IsStaffAsync(organizationId, staffId);
        }

        public async Task<bool> IsOwnerAsync(int organizationId, string userId)
        {
            return await _unitOfWork.Organizations.IsOwnerAsync(organizationId, userId);
        }
    }
}
