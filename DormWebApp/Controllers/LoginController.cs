using DormWebApp.Classes;
using DormWebApp.Data.Infrastructure;
using DormWebApp.Domain.Entities;
using DormWebApp.Services.Interfaces;
using DormWebApp.Services.Services;
using DormWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DormWebApp.Controllers
{
    public class LoginController : Controller
    {
        private Repository<User> userRepository;
        private Repository<Role> roleRepository;
        private DatabaseFactory databasefactory;
        private IUserServices userService;
        public LoginController()
        {
            databasefactory = new DatabaseFactory();
            roleRepository = new Repository<Role>(databasefactory);
            userRepository = new Repository<User>(databasefactory);
            userService = new UserServices(databasefactory);
        }
        // GET: Login
        [HttpPost,ValidateAntiForgeryToken,AllowAnonymous]
        public ActionResult Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = this.userService.GetUserByEmail(model.Email);
                string hashedPassword = Security.HashSHA1(model.Password + user.UniqueKey);

                if(hashedPassword == user.Password)
                {
                    DormIdentity.CurrentUser = user;
                    FormsAuthentication.SetAuthCookie(user.Email, model.RememberMe);
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    FormsAuthentication.Authenticate(user.Email, hashedPassword);

                    if(DormIdentity.CurrentUser.Role.Id == (int)Core.Roles.Admin)
                    {
                        return RedirectToAction("Index", "Dorm", new { area = "Admin" });
                    }
                }
                return Redirect(returnUrl);
            }
            return View("../Home/Index",model);
        }
    }
}