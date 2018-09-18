using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Model.Entities;
using Shop.Model.Interfaces;
using Shop.API.Models;
using Shop.Model.Parameters;

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
        public IActionResult Get(ProductParameters param)
        {
            var products = repository.GetProducts(param);
            return Ok(products);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return repository.GetProductById(id);
        }

        // GET api/products/5/categories
        [HttpGet("{id}/categories")]
        public IEnumerable<CategoryModel> GetCategories(int id)
        {
             return repository.GetCategoriesByProductId(id).Select(cat => mapper.Map<CategoryModel>(cat));
        }

        // GET api/products/5/categorytree
        [HttpGet("{id}/categorytree")]
        public CategoryModel GetCategoryTree(int id)
        {
            return mapper.Map<CategoryModel>(repository.GetCategoryTreeByProductId(id));
        }
    }
}