using Core.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal
{
    public interface IProductDal : IRepository<Products>
    {
    }
}
