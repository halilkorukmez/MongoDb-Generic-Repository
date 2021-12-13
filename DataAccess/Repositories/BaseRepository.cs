using Core.Model;
using DataAccess.DataContext.MongoContext;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;

            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.InsertOneAsync(entity);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("Id", id));
            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public async Task UpdateAsync(TEntity entity, string id)
        {
            await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", id), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

    }
}
