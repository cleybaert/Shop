using System.Collections.Generic;

namespace Shop.Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IEnumerable<string> AvailableSizes { get; set; }
        public string Url { get; set; }
        public IEnumerable<ProductPreview> Previews { get; set; }

        public virtual IEnumerable<Category> Categories { get; set; }
    }
}
