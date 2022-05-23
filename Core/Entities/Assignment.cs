using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Assignment : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public Constants.Task.TaskStatus Status { get; set; }

        #region NavigationProperties

        public ICollection<Staff> Staffs { get; set; }

        #endregion
    }
}
