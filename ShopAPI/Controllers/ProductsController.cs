using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Model.Entities;
using Shop.Model.Interfaces;

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository repository;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }

        // GET api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return repository.GetProducts();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return repository.GetProductById(id);
        }
    }
}