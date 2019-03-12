using DormWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Domain.Context
{
    public class Context : DbContext
    {
        public Context() : base("name=DormWebApp")
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Dorm> Dorms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
