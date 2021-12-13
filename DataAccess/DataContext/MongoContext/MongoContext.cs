using Core.Extension.Repositories;
using Core.Model.Mongo;
using Core.Settings;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;


namespace DataAccess.DataContext.MongoContext
{
    public class MongoContext<TEntity> : IMongoContextModel<TEntity> where TEntity : class, new()
    {
        private readonly IMongoDatabase _database ;
        public MongoContext(IMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection()
        {
            return _database.GetCollection<TEntity>(new TEntity().GetCollectionName());
        }
    }
}
