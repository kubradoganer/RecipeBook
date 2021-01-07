using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity, TContext>
        where TEntity : BaseEntity
        where TContext : DbContext
    {

        public BaseRepository(TContext context)
        {
            this.Context = context;
        }

        protected TContext Context
        {
            get;
            private set;
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return this.Context.Set<TEntity>();
            }
        }

        private void AddEntity(TEntity entity)
        {
            this.OnAddEntity(entity);
        }

        private void UpdateEntity(TEntity entity)
        {
            this.OnUpdateEntity(entity);
        }

        protected virtual void OnAddEntity(TEntity entity)
        {
        }

        protected virtual void OnUpdateEntity(TEntity entity)
        {
        }

        protected void Save()
        {
            this.Context.SaveChanges();
        }

        public virtual TEntity Find(int id)
        {
            return this.DbSet
                .Where(i => i.Id == id)
                .FirstOrDefault();
        }

        public virtual List<TEntity> GetList()
        {
            return this.DbSet
                .ToList();
        }

        public virtual TEntity Add(TEntity entity)
        {
            this.AddEntity(entity);
            this.DbSet.Add(entity);

            return entity;
        }

        public virtual TEntity AddWithSave(TEntity entity)
        {
            this.AddEntity(entity);
            this.DbSet.Add(entity);
            this.Save();

            return entity;
        }

        public virtual void AddAll(List<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                this.AddEntity(entity);
            }

            this.DbSet.AddRange(entityList);
        }

        public virtual void AddAllWithSave(List<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                this.AddEntity(entity);
            }

            this.DbSet.AddRange(entityList);
            this.Save();
        }

        public virtual TEntity Update(TEntity entity)
        {
            this.UpdateEntity(entity);
            this.DbSet.Update(entity);
            return entity;
        }

        public virtual TEntity UpdateWithSave(TEntity entity)
        {
            this.UpdateEntity(entity);
            this.DbSet.Update(entity);
            this.Save();

            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }

        public virtual void DeleteWithSave(TEntity entity)
        {
            this.DbSet.Remove(entity);
            this.Save();
        }
    }
}
