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

        /// <summary>
        /// Получаем все элементы сущности
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> SelectAll()
        {
            return DbSet.AsEnumerable();
        }

        /// <summary>
        /// Получаем сущность по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T SelectByID(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Добавляем элемент в бд
        /// </summary>
        /// <param name="entity"></param>
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
                // Элемент не найден -> уже удален
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