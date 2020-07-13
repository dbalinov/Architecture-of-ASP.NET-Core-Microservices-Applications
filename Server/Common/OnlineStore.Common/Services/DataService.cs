﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Common.Services
{
    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : class
    {
        protected DataService(DbContext db)
            => this.Data = db;

        protected DbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public Task SaveAsync(TEntity entity)
        {
            this.Data.Update(entity);

            return this.Data.SaveChangesAsync();
        }
    }
}
