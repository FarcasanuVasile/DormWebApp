using DormWebApp.Data.Infrastructure;
using DormWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Services.Services
{
    public class RoomServices
    {
        private DatabaseFactory databaseFactory;
        private Repository<Room> roomRepository;
        private IUnitOfWork unitOfWork;

        public RoomServices(DatabaseFactory dbFactory)
        {
            this.databaseFactory = dbFactory;
            this.roomRepository = new Repository<Room>(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }
        
    }
}
