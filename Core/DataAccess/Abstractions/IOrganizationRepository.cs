using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstractions
{
    public interface IOrganizationRepository : IBaseRepository<Organization>
    {
        Task<bool> IsStaffAsync(int organizationId, string staffId);
        Task<bool> IsOwnerAsync(int organizationId, string userId);
    }
}
