using DormWebApp.Areas.Admin.Models;
using DormWebApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormWebApp.Areas.Admin.Controllers
{
    public class FloorController : Controller
    {
        private Repository<Domain.Entities.Floor> floorRepository;
        private Repository<Domain.Entities.Room> roomRepository;
        private IUnitOfWork unitOfWork;
        private DatabaseFactory dbFactory;

        

        // GET: Admin/Floor
        public ActionResult Index()
        {
            var floors = floorRepository.GetAll();
            IEnumerable<Floor> floorsView = floors.Select(f => new Floor() {

            });
            return View();
        }
    }
}