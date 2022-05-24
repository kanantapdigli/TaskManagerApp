using Core.Entities;
using System.Collections.Generic;

namespace Manage.Models.Assignment
{
    public class AssignmentIndexViewModel
    {
        public string OrganizationName { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public List<Core.Entities.Assignment> Assignments { get; set; }
    }
}
