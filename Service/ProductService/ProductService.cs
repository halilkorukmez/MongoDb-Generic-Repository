using Core.Repositories;
using DataAccess.Dal;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.ProductService
{
    public class ProductService : IProductService
    {
        private IProductDal  _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task AddAsync(Products product)
        {

           await _productDal.AddAsync(product);
            

        }

        public async Task DeleteAsync(string id)
        {
            await _productDal.DeleteAsync( id);
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
           return await _productDal.GetAllAsync();
        }

        public async Task<Products> GetByIdAsync(string id)
        {
            return await _productDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Products product, string id)
        {
             await _productDal.UpdateAsync(product,id);
        }
    }
}
