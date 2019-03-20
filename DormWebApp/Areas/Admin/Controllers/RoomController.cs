using DormWebApp.Data.Infrastructure;
using DormWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormWebApp.Areas.Admin.Controllers
{
    public class RoomController : Controller
    {

        private Repository<Room> roomRepository;
        private Repository<Floor> floorRepository;
        private DatabaseFactory dbFactory;
        private IUnitOfWork unitOfWork;

        public RoomController()
        {
            this.dbFactory = new DatabaseFactory();
            this.roomRepository = new Repository<Room>(dbFactory);
            this.floorRepository = new Repository<Floor>(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        // GET: Admin/Room
        public ActionResult Index()
        {
            var rooms = roomRepository.GetAll();
            IEnumerable<Models.Room> roomsView = rooms.Select( r => new Models.Room() {
                Id = r.Id,
                RoomNo = r.RoomNo,
                Capacity = r.Capacity,
                IsAvaible = r.IsAvaible
            });
            return View(roomsView);
        }
        [HttpGet]
        public ActionResult RoomsOfFloor(int id)
        {
            var floor = floorRepository.GetById(id);
            var rooms = roomRepository.GetAll();
            var roomList = new List<Room>();
            foreach(var room in rooms)
            {
                if(room.FloorId == floor.Id)
                {
                    roomList.Add(room);
                }
            }
            IEnumerable<Models.Room> roomsView = roomList.Select(r => new Models.Room {
                Id = r.Id,
                RoomNo = r.RoomNo,
                Capacity = r.Capacity,
            });
            ViewBag.FloorNo = "Rooms of floor " + floor.FloorNo;
            return View(roomsView);
        }
        
    }
}