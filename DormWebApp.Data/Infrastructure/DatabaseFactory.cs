using DormWebApp.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private Context context;

        public Context Get()
        {
            return context ?? (context= new Context());
        }
        protected override void DisposeCore()
        {
            context?.Dispose();
        }
    }
}
