using DormWebApp.Domain.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Data.Infrastructure
{
    public class Repository<T> where T : class
    {
        private Context context;
        private readonly IDbSet<T> dbSet;
        public Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbSet = Context.Set<T>();
        }
        public IDatabaseFactory DatabaseFactory { get; }
        protected Context Context { get { return context??(context = DatabaseFactory.Get()); } }

        //CRUD

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual int Count()
        {
            return dbSet.Count();
        }

    }
}
