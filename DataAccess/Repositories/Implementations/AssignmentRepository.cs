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
    public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
    {
        private readonly TaskManagerAppContext _db;

        public AssignmentRepository(TaskManagerAppContext db)
            :base(db)
        {
            _db = db;
        }

        public async Task<List<Assignment>> GetAllByDescendingAsync()
        {
            return await _db.Assignments
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }

        public async Task<List<Assignment>> GetAllByDescendingWithStaffsAsync()
        {
            return await _db.Assignments
                           .Include(a => a.Staffs)
                           .OrderByDescending(a => a.Id)
                           .ToListAsync();
        }

        public async Task<List<string>> GetStaffIdsAsync(int assignmentId)
        {
            var assignment = await _db.Assignments
                            .Include(a => a.Staffs)
                            .FirstOrDefaultAsync(a => a.Id == assignmentId);

            var staffIds = new List<string>();

            foreach (var staff in assignment.Staffs)
                staffIds.Add(staff.Id);

            return staffIds;
        }

        public async Task<Assignment> GetWithStaffsAsync(int assignmentId)
        {
            return await _db.Assignments
                                    .Include(a => a.Staffs)
                                    .FirstOrDefaultAsync(a => a.Id == assignmentId);
        }
    }
}
