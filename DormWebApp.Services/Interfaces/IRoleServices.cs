using DormWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Services.Interfaces
{
    interface IRoleServices
    {
        void AddRole(Role role);
        void EditRole(Role role);
        void DeleteRole(Role role);
        bool ExistingRole(string name);
    }
}
