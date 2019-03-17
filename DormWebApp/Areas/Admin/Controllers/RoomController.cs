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
        public ActionResult RoomsOfFloor(int id)
        {
            var floor = floorRepository.GetById(id);
            var rooms = roomRepository.GetAll().Where(f => f.FloorId == id);
            IEnumerable<Models.Room> roomsView = rooms.Select(r => new Models.Room() {
                Id = r.Id,
                RoomNo = r.RoomNo,
                Capacity = r.Capacity,

            });
            return View(roomsView);
        }
        
    }
}