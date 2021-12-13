using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProductService
{
    public interface IProductService
    {
        Task AddAsync(Products product);
        Task<Products> GetByIdAsync(string id);
        Task<IEnumerable<Products>> GetAllAsync();
        Task UpdateAsync(Products product, string id);
        Task DeleteAsync(string id);
    }
}
