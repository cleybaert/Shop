using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Model.Interfaces;
using Shop.Model.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoryController : Controller
    {
        private readonly IProductRepository repository;

        public CategoryController(IProductRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return repository.GetCategories();
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public Category Get(int id, bool simple = true)
        {
            if (simple)
                return repository.GetCategoryById(id);
            else
                return repository.GetCategoryTreeById(id);
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
