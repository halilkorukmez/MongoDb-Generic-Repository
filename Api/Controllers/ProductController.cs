using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productRepository;
        public ProductController(IProductService productRepository)
        {
            _productRepository = productRepository;
          
        }


        [HttpPost("[action]")]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Products>> AddProducts([FromBody] Products products)
        {
            await _productRepository.AddAsync(products);
            return CreatedAtRoute("GetById", new { id = products.Id }, products);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetById")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Products>> GetById(string id)
        {
            var products = await _productRepository.GetByIdAsync(id);
            if (products == null)
              return NotFound();

            return Ok(products);
        }

        [HttpPut("[action]")]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct(Products products,string id)
        {
             await _productRepository.UpdateAsync(products,id);
            return Ok();
        }

        [HttpDelete("{id:length(24)}", Name = "Delete")]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productRepository.DeleteAsync( id);
            return Ok();
        }
    }
}
