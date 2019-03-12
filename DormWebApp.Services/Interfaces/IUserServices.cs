using DormWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Services.Interfaces
{
    public interface IUserServices
    {
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(User user);
        bool ExistingUsername(string username);
        bool ExistingEmailAddress(string email);
        User GetUserByEmail(string email);
    }
}
