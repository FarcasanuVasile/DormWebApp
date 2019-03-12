using DormWebApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormWebApp.Filters
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public Core.Roles[] AllowedRoles;
        public AuthorizeRolesAttribute(params Core.Roles[] roles)
        {
            AllowedRoles = roles;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}