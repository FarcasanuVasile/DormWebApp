using DormWebApp.Domain.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private Context context;
        
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected Context DataContext
        {
            get { return context ?? (context = databaseFactory.Get()); }
        }
        public void Commit()
        {
            try
            {
                DataContext.SaveChanges();
            }
             catch(DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach(var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach(var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat(" - {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity validation failed - errors follow\n" + sb.ToString(), ex);
            }
            
        }
        
    }
}
