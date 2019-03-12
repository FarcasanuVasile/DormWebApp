using DormWebApp.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DormWebApp.Classes
{
    public class AuthorizationRoleMapper
    {
        public static Core.Roles GetRoleFlag ( Role userRole)
        {
            if(userRole.Name == "Admin")
            {
                return Core.Roles.Admin;
            }
            if(userRole.Name == "User")
            {
                return Core.Roles.User;
            }
            return Core.Roles.User;
        }
    }
}