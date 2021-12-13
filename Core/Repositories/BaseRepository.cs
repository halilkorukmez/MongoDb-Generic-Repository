using Core.Model;
using Core.Model.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly IMongoContextModel<TEntity> _context;
        protected readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(IMongoContextModel<TEntity> context)
        {
            _context = context;
            _collection = _context.GetCollection();
        }

        public async Task AddAsync(TEntity entity)
        {
            await  _collection.InsertOneAsync(entity);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var data = await _collection.FindAsync(Builders<TEntity>.Filter.Eq("Id", id));
            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var all = await _collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public async Task UpdateAsync(TEntity entity, string id)
        {
            await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", id), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
