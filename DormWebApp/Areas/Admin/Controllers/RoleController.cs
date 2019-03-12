using DormWebApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormWebApp.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private IUnitOfWork unitOfWork;
        private Repository<Domain.Entities.Role> roleRepository;
        private DatabaseFactory dbFactory;

        public RoleController()
        {
            this.dbFactory = new DatabaseFactory();
            this.roleRepository = new Repository<Domain.Entities.Role>(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            var roles = roleRepository.GetAll();
            IEnumerable<User.Models.Role> rolesView = roles.Select(r => new User.Models.Role() {
                Id = r.Id,
                Name = r.Name
            });
            return View(rolesView);
        }
    }
}