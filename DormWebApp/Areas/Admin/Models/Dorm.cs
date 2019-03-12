using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormWebApp.Areas.Admin.Models
{
    public class Dorm
    {
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Display(Name = "Floors")]
        public  int NoOfFloors { get; set; }
        [Display(Name="Rooms per floor")]
        public int? NoOfRoomsPerFloor { get; set; }
        [Display(Name="Room Capacity")]
        public int RoomCapacity { get; set; }
        public ICollection<Floor> Floors { get; set; }
        [Display(Name="Rooms Avaible")]
        public int RoomsAvaible { get; set; }
        [Display(Name = "Places Avaible")]
        public int PlacesAvaible { get; set; }

        public Dorm()
        {
            Floors = new List<Floor>();
        }

    }
}