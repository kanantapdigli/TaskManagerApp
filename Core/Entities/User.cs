using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : IdentityUser, IEntity
    {
        public string Fullname { get; set; }

        public Organization Organization { get; set; }
    }
}
