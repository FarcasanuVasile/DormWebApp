using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormWebApp.Areas.Admin.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public int DormId { get; set; }
        [Display(Name = "Rooms")]
        public int? NoOfRooms { get; set; }
        [Display(Name ="Floor")]
        public int FloorNo { get; set;  }
        [Display(Name = "Rooms Avaible")]
        public int? RoomsAvaible { get; set; }
        [Display(Name = "Places Avaible")]
        public int? PlacesAvaible { get; set; }
        public Dorm Dorm { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public Floor()
        {
            Rooms = new List<Room>();
        }
    }
}