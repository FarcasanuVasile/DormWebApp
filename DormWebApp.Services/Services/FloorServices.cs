using DormWebApp.Data.Infrastructure;
using DormWebApp.Domain.Entities;
using DormWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Services.Services
{
    public class FloorServices : IFloorServices
    {
        private DatabaseFactory dbFactory;
        private Repository<Floor> floorRepository;
        private Repository<Dorm> dormRepository;
        private readonly IUnitOfWork unitOfWork;

        public FloorServices(DatabaseFactory databaseFactory)
        {
            this.dbFactory = databaseFactory;
            this.floorRepository = new Repository<Floor>(databaseFactory);
            this.unitOfWork = new UnitOfWork(databaseFactory);
        }

        public int GetNoOfRoomsAvaible(int id)
        {
            var countRooms=0;
            var dorm = dormRepository.GetById(id);
            var floors = floorRepository.GetAll().Where(x=> x.DormId == id);
            foreach (var floor in floors)
            {
                countRooms = floor.Rooms.Count(x => x.IsAvaible == true);
                floor.RoomsAvaible = countRooms;
            }
            return countRooms;
        }

    }
}
