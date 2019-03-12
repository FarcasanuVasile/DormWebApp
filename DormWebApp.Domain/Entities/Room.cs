using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public int Capacity { get; set; }
        public bool IsAvaible { get; set; }
        public int FloorId { get; set; }

        public Floor Floor { get; set; }
    }
}
