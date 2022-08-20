using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiAssignment.Data
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly Context dbcontext;

        public Repository(Context context)
        {
            dbcontext = context;
        }

        protected virtual IQueryable<TEntity> AsQueryable()
        {
            return dbcontext.Set<TEntity>();
        }

        protected virtual void Delete(TEntity entity)
        {
            dbcontext.Set<TEntity>().Remove(entity);
        }

        protected virtual void Insert(TEntity entity)
        {
            dbcontext.Set<TEntity>().Add(entity);
        }

        protected virtual void Update(TEntity entity)
        {
            dbcontext.Entry(entity).State = EntityState.Modified;
        }
    }
}
