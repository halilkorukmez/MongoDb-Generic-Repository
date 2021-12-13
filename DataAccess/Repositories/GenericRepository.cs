using DataAccess.DataContext.MongoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {
        public GenericRepository(IMongoContext context) : base(context)
        {
           
        }
    }
}
