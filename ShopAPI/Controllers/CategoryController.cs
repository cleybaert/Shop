using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Model.Interfaces;
using Shop.Model.Entities;
using System.Linq;
using ShopAPI.Models;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoryController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public CategoryController(
            IProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET: api/categories
        [HttpGet]
        public IEnumerable<CategoryModel> Get(bool full = false)
        {
            if (full)
                return repository.GetFullCategories()
                                    .Select(c => mapper.Map<CategoryModel>(c));
            else
                return repository.GetCategories()
                                    .Select(c => mapper.Map<CategoryModel>(c));
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public CategoryModel Get(int id, bool full = false)
        {
            if (full)
                return mapper.Map<CategoryModel>(repository.GetFullCategoryById(id));
            else
                return mapper.Map<CategoryModel>(repository.GetCategoryById(id));            
        }

        // GET api/categories/5
        [HttpGet("{id}/products")]
        public IEnumerable<ProductModel> GetProducts(int id)
        {
            return repository.GetProductsByCategoryId(id).Select(prod => mapper.Map<ProductModel>(prod));
        }

        private Exception HttpResponseException()
        {
            throw new NotImplementedException();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
