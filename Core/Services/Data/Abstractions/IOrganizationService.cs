using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstractions
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetAllAsync();
        Task<Organization> GetAsync(int id);
        Task CreateAsync(Organization organization);
        Task UpdateAsync(Organization organization);
        Task DeleteAsync(Organization organization);
        Task<bool> IsStaffAsync(int organizationId, string staffId);
        Task<bool> IsOwnerAsync(int organizationId, string userId);
    }
}
