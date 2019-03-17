using DormWebApp.Areas.Admin.Models;
using DormWebApp.Data.Infrastructure;
using DormWebApp.Services.Interfaces;
using DormWebApp.Services.Services;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormWebApp.Areas.Admin.Controllers
{
    public class DormController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        private Repository<Domain.Entities.Dorm> dormRepository;
        private Repository<Domain.Entities.Floor> floorRepository;
        private Repository<Domain.Entities.Room> roomRepository;
        private IDormServices dormServices;
        private IFloorServices floorServices;
        private DatabaseFactory dbFactory;

        public DormController()
        {
            dbFactory = new DatabaseFactory();
            this.unitOfWork = new UnitOfWork(dbFactory);
            this.dormRepository = new Repository<Domain.Entities.Dorm>(dbFactory);
            this.floorRepository = new Repository<Domain.Entities.Floor>(dbFactory);
            this.roomRepository = new Repository<Domain.Entities.Room>(dbFactory);
            this.dormServices = new DormServices(dbFactory);
            this.floorServices = new FloorServices(dbFactory);
        }
        // GET: Admin/Dorm
        public ActionResult Index()
        {
            var dorms = dormRepository.GetAll();
            IEnumerable<Dorm> dormsView = dorms.Select(d => new Dorm()
            {
                Id = d.Id,
                Name = d.Name,
                NoOfFloors = d.NoOfFloors,
                NoOfRoomsPerFloor = d.NoOfRoomsPerFloor,
                RoomCapacity = d.RoomCapacity,
                RoomsAvaible = d.RoomsAvaible,
                PlacesAvaible = d.PlacesAvaible


            });
            return View(dormsView);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            var dorm = new Dorm();
            return View(dorm);
        }
        [HttpPost]
        public ActionResult Create(Dorm dorm)
        {
            var success = false;
            if (ModelState.IsValid) {
                var dbModel = new Domain.Entities.Dorm();
                dbModel.InjectFrom(dorm);
                success = dormServices.AddDorm(dbModel);
            }
            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Dorm is already in database.";
                return View(dorm);
            }
        }
        [HttpGet]
        public ActionResult GetFloorsOfDorm(int id)
        {
            var dorm = dormRepository.GetById(id);
            var floors = floorRepository.GetAll();
            ViewBag.DormName = dorm.Name;
            var floorsList = new List<Domain.Entities.Floor>();
            foreach (var floor in floors)
            {
                if (floor.DormId == dorm.Id)
                {
                    floorsList.Add(floor);
                }
            }
            IEnumerable<Floor> floorsOfDormView = floorsList.Select(f => new Floor
            {
                Id = f.Id,
                DormId = f.DormId,
                FloorNo = f.FloorNo,
                NoOfRooms = f.NumberOfRooms,
                RoomsAvaible = f.RoomsAvaible,
                PlacesAvaible = f.PlacesAvaible
            });
            return View(floorsOfDormView);
        }
        [HttpGet]
        public ActionResult GetRoomsByFloorId (Dorm dorm, int id)
        {
            var floor = floorRepository.GetById(id);
            var rooms = roomRepository.GetAll().Where(r => r.Id == id && r.Floor.DormId == dorm.Id);
            IEnumerable<Room> roomsView = rooms.Select(r => new Room
            {
                Id = r.Id,
                RoomNo = r.RoomNo,
                IsAvaible = r.IsAvaible,
                Capacity = r.Capacity
            });
            return View(roomsView);
        }
    }
}