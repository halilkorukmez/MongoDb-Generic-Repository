using Core.Model.Mongo;
using Core.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal
{
    public class ProductDal : BaseRepository<Products>, IProductDal
    {
        public ProductDal(IMongoContextModel<Products> context) : base(context)
        {
        }
    }
}
