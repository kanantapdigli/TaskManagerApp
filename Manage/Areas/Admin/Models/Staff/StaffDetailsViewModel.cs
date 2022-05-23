using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.Staff
{
    public class StaffDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Full name")]
        public string Fullname { get; set; }

        public string Email { get; set; }
    }
}
