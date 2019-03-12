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
    public class DormServices : IDormServices
    {
        private DatabaseFactory dbFactory;
        private Repository<Dorm> dormRepository;
        private readonly IUnitOfWork unitOfWork;

        public DormServices(DatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            this.dormRepository = new Repository<Dorm>(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        public bool AddDorm(Dorm dorm)
        {
            var result = false;
            var existingProduct = ExistDormName(dorm.Name);
            if (!existingProduct) {
                for (int i = 0; i < dorm.NoOfFloors; i++)
                {
                    dorm.Floors.Add(new Floor() { NumberOfRooms = dorm.NoOfRoomsPerFloor, FloorNo = i,RoomsAvaible = dorm.NoOfRoomsPerFloor,PlacesAvaible = dorm.NoOfRoomsPerFloor * dorm.RoomCapacity});
                }
                for ( int i = 1; i <= dorm.NoOfRoomsPerFloor; i++)
                {
                    
                    foreach ( var floor in dorm.Floors)
                    {
                        floor.Rooms.Add(new Room() { RoomNo = floor.FloorNo * 100 + i ,IsAvaible = true,Capacity = dorm.RoomCapacity,});
                    }
                }
                dorm.PlacesAvaible = (int)dorm.NoOfRoomsPerFloor * dorm.RoomCapacity * dorm.NoOfFloors;
                dorm.RoomsAvaible = (int)dorm.NoOfRoomsPerFloor * dorm.NoOfFloors ;
                dormRepository.Add(dorm);
                unitOfWork.Commit();
                result = true;
            }
            return result;
        }
        public void EditDorm(Dorm dorm)
        {
            dormRepository.Update(dorm);
            unitOfWork.Commit();
        }
        public void DeleteDorm(Dorm dorm)
        {
            dormRepository.Delete(dorm);
            unitOfWork.Commit();
        }
        public bool ExistDormName(string dormName)
        {
            var dormCount = dormRepository.GetAll().
                Count(x => x.Name.ToLower().Replace(" ", string.Empty) == dormName.ToLower().Replace(" ", string.Empty));
            return dormCount > 0;
        }

    }
}
