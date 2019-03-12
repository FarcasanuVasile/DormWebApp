using DormWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Services.Interfaces
{
    public interface IDormServices
    {
        bool AddDorm(Dorm dorm);
        void EditDorm(Dorm dorm);
        void DeleteDorm(Dorm dorm);
        bool ExistDormName(string name);
    }
}
