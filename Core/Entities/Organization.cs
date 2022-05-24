using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Organization : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        #region NavigationProperties

        public User Owner { get; set; }
        public string OwnerId { get; set; }

        public ICollection<Staff> Staffs { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

        #endregion
    }
}
