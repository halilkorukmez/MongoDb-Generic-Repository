using DataAccess.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Products> _repository;

        public ProductService(IRepository<Products> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Products product)
        {

           await _repository.AddAsync(product);
            

        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync( id);
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<Products> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Products product, string id)
        {
             await _repository.UpdateAsync(product,id);
        }
    }
}
