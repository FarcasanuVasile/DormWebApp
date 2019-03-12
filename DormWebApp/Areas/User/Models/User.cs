using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormWebApp.Areas.User.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? RegisterOn { get; set; }
        public string UniqueKey { get; set; }
        [Display(Name = "User Type")]
        public string RoleName { get; set; }

        public virtual Role Role { get; set; }

        public User()
        {

        }
    }
}