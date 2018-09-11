using System;
using System.Collections.Generic;
using System.IO;
using Shop.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Newtonsoft.Json;
using Shop.Extensions;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoryController : Controller
    {
        // GET: api/categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return new JsonReader<Category>().Read("categories.json");
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var categories = Get();
            foreach (var item in categories)
            {
                if (item.Id == id)
                    return Ok(item);
                foreach (var subitem in item.Descendants())
                {
                    if (subitem != null)
                    {
                        if (subitem.Id == id)
                            return Ok(subitem);
                    }
                }
            }
            return NotFound();
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
