using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Staff : IdentityUser, IEntity
    {
        public string Fullname { get; set; }

        #region NavigationProperties

        public Organization Organization { get; set; }

        public int OrganizationId { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

        #endregion
    }
}
