using DormWebApp.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        Context Get();

        void Dispose();
    }
}
