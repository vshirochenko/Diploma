using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Diploma.DAL.Repositories
{
    public class MunicipalityRepository<T> : IMunicipalityRepository<T> where T : class 
    {
        public DbContext DbContext { get; set; }
        public DbSet<T> DbSet { get; set; }

        public MunicipalityRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("Null DbContext");
            }
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public IQueryable<T> SelectAll()
        {
            return DbSet;
        }

        // Get entity by id
        public T SelectByID(object id)
        {
            return DbSet.Find(id);
        }

        // Add entity to db
        public void Insert(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = SelectByID(id);
            if (entity == null)
            {
                // Not found. Already is deleted.
                return;
            }
            Delete(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}