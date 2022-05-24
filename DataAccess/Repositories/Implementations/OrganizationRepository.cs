using Core.DataAccess.Abstractions;
using Core.Entities;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        private readonly TaskManagerAppContext _db;

        public OrganizationRepository(TaskManagerAppContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> IsOwnerAsync(int organizationId , string userId)
        {
            return await _db.Organizations.AnyAsync(o => o.Id == organizationId && o.OwnerId == userId);
        }

        public async Task<bool> IsStaffAsync(int organizationId, string staffId)
        {
            return await _db.Organizations
                                        .AnyAsync(o => o.Id == organizationId && o.Staffs.Any(s => s.Id == staffId));
        }
    }
}
