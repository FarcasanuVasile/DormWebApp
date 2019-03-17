using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Services.Interfaces
{
    interface ISecurityServices
    {
        void HashPassowrd(string value);
    }
}
