using DormWebApp.Classes;
using DormWebApp.Data.Infrastructure;
using DormWebApp.Services.Interfaces;
using DormWebApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormWebApp.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private DatabaseFactory dbFactory;
        private Repository<Domain.Entities.User> userRepository;
        private Repository<Domain.Entities.Role> rolesRepository;
        private IUnitOfWork unitOfWork;
        private IUserServices userServices;
        public UserController()
        {
            var dbFactory = new DatabaseFactory();
            this.userServices = new UserServices(dbFactory);
            this.userRepository = new Repository<Domain.Entities.User>(dbFactory);
            this.rolesRepository = new Repository<Domain.Entities.Role>(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }
        
        // GET: User/User
        [HttpGet]
        public ActionResult Index(string sortOrder , string searchString)
        {
            var users = userRepository.GetAll();
            IEnumerable<Models.User> usersView = users.Select(u => new Models.User {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                Email = u.Email,
                IsActive = u.IsActive,
                RoleId = u.RoleId,
                RegisterOn = u.RegisterOn
            });
            //var ss = DormIdentity.CurrentUser.Id;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "username_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var search = from s in userRepository.GetAll() select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                usersView = usersView.Where(u => u.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstname_desc":
                    usersView = usersView.OrderByDescending(s => s.FirstName);
                    break;
                case "lastname_desc":
                    usersView = usersView.OrderByDescending(s => s.LastName);
                    break;
                case "username_desc":
                    usersView = usersView.OrderByDescending(s => s.Username);
                    break;
                case "date_desc":
                    usersView = usersView.OrderByDescending(s => s.RegisterOn);
                    break;
                default:
                    usersView = usersView.OrderByDescending(s => s.FirstName);
                    break;
            }

            return View(usersView);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new Models.User();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Models.User user)
        {
            var roleToAssign = rolesRepository.GetById(2);
            Models.Role roleConverted = new Models.Role() { Id = roleToAssign.Id , Name = roleToAssign.Name };
            user.RegisterOn = DateTime.Now;
            user.Role = roleConverted;
            user.RoleId = roleConverted.Id;
            if (ModelState.IsValid)
            {
                if (userServices.ExistingEmailAddress(user.Email))
                {
                    ModelState.AddModelError("Email", "This email address can not be used.");
                }
                if (userServices.ExistingUsername(user.Username))
                {
                    ModelState.AddModelError("Email", "This username can not be used.");
                }
                if(!userServices.ExistingUsername(user.Username) && !userServices.ExistingEmailAddress(user.Email))
                {
                    var dbModel = new Domain.Entities.User();
                    TryUpdateModel(dbModel);
                    userServices.AddUser(dbModel);
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            return View(user);
        }
    }
}