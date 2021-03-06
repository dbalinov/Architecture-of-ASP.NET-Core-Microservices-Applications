﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Data.Models;

namespace OnlineStore.Common.Services
{
    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : class
    {
        protected DataService(DbContext db)
            => this.Data = db;

        protected DbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task MarkMessageAsPublished(int id)
        {
            var message = await this.Data.FindAsync<Message>(id);

            message.MarkAsPublished();

            await this.Data.SaveChangesAsync();
        }

        public Task SaveAsync(TEntity entity, params Message[] messages)
        {
            foreach (var message in messages)
            {
                this.Data.Add(message);
            }

            this.Data.Update(entity);

            return this.Data.SaveChangesAsync();
        }
    }
}
