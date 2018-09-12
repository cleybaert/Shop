using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ProductPreview
    {
        public string Thumbnail { get; set; }
        public string Detail { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IEnumerable<string> AvailableSizes { get; set; }
        public string Url { get; set; }
        public IEnumerable<ProductPreview> Previews { get; set; }
    }
}
