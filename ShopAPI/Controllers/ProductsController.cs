using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.Extensions;

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        // GET api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return new JsonReader<Product>().Read("products.json");
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return Get().First(x => x.Id == id);
        }
    }
}