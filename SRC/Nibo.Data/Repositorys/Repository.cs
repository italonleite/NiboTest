using Microsoft.EntityFrameworkCore;
using Nibo.Business.Interfaces;
using Nibo.Business.Models;
using Nibo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nibo.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MyDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MyDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public Repository()
        {

        }


        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task Save(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }
    }
}
