using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Domain.Entities
{
    public class Dorm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfFloors { get; set; }
        public int? NoOfRoomsPerFloor { get; set; }
        public int RoomCapacity { get; set; }
        public int RoomsAvaible { get; set; }
        public int PlacesAvaible { get; set; }

        public ICollection<Floor> Floors { get; set; }

        public Dorm()
        {
            Floors = new List<Floor>(); 
           
        }

    }
}
