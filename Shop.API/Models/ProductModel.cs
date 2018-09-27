using Shop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IEnumerable<string> AvailableSizes { get; set; }
        public string Url { get; set; }
        public IEnumerable<ProductPreview> Previews { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
