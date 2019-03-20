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
        private Repository<Domain.Entities.Dorm> dormRepository;
        private IUnitOfWork unitOfWork;
        private DatabaseFactory dbFactory;

        public FloorController()
        {
            this.dbFactory = new DatabaseFactory();
            this.floorRepository = new Repository<Domain.Entities.Floor>(dbFactory);
            this.dormRepository = new Repository<Domain.Entities.Dorm>(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        // GET: Admin/Floor
        [HttpGet]
        public ActionResult Index()
        {
            var floors = floorRepository.GetAll();
            IEnumerable<Floor> floorsView = floors.Select(f => new Floor() {
                Id=f.Id,
                FloorNo = f.FloorNo,
                NoOfRooms = f.NumberOfRooms,
                RoomsAvaible = f.RoomsAvaible,
                PlacesAvaible = f.PlacesAvaible
            });
            return View();
        }
        [HttpGet]
        public ActionResult GetFloorsByDorm(int id)
        {
            var dorm = dormRepository.GetById(id);
            var floors = floorRepository.GetAll();
            var floorList = new List<Domain.Entities.Floor>();
            foreach(var floor in floors)
            {
                if (floor.DormId == dorm.Id)
                {
                    floorList.Add(floor);
                }
            }
            IEnumerable<Floor> floorsView = floorList.Select(r => new Floor {
                Id=r.Id,
                FloorNo = r.FloorNo,
                NoOfRooms = r.NumberOfRooms,
                RoomsAvaible = r.RoomsAvaible,
                PlacesAvaible = r.PlacesAvaible
            });
            return View(floorsView);
        }
    }
}