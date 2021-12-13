using Core.Model.Mongo;
using Core.Repositories;
using System;

namespace Core.Extension.Repositories
{
    public static class GenericRepository
    {
        public static string GetCollectionName<T>(this T entity) where T : class, new()
        {
            var collection = (Collection)Attribute.GetCustomAttribute(typeof(T), typeof(Collection));
            return collection.Name;
        }
    }
}
