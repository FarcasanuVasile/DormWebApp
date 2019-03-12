using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Domain.Entities
{
    public class Floor
    {
        public int Id { get; set; }
        public int FloorNo { get; set; }
        public int? NumberOfRooms { get; set; }
        public int DormId { get; set; }
        public int? RoomsAvaible { get; set; }
        public int? PlacesAvaible { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public Floor()
        {
            Rooms = new List<Room>();
        }
    }
}
