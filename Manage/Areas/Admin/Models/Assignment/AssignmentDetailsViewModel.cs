using Core.Constants.Task;
using System;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.Assignment
{
    public class AssignmentDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public DateTime Deadline { get; set; }

        public ICollection<Core.Entities.Staff> Staffs { get; set; }
    }
}
