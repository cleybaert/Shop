using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Model.Entities;
using Shop.Model.Interfaces;
using ShopAPI.Models;

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductsController(
            IProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET api/products
        [HttpGet]
        public IEnumerable<ProductModel> Get(bool categories = false)
        {
            if (categories)
                return repository.GetProductsWithCategories().Select(prod => mapper.Map<ProductModel>(prod));
            else
                return repository.GetProducts().Select(prod => mapper.Map<ProductModel>(prod));
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return repository.GetProductById(id);
        }

        // GET api/products/5
        [HttpGet("{id}/categories")]
        public IEnumerable<CategoryModel> GetCategories(int id, bool full = false)
        {
            if (full)
                return repository.GetFullCategoriesByProductId(id).Select(cat => mapper.Map<CategoryModel>(cat));
            else
                return repository.GetCategoriesByProductId(id).Select(cat => mapper.Map<CategoryModel>(cat));
        }
    }
}